#nullable disable

using Application.Emails;
using Application.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Areas.Identity.Pages
{
    [AllowAnonymous]
    public class ResendEmailConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailer emailer;

        public ResendEmailConfirmationModel(
            UserManager<ApplicationUser> userManager,
            IEmailer emailer)
        {
            this.userManager = userManager;
            this.emailer = emailer;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public bool DisplayVerificationLink { get; private set; }
        public string VerificationLink { get; private set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Verification email sent. Please check your email.");
                return Page();
            }

            var userId = await userManager.GetUserIdAsync(user);
            var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var varificationLink = Url.Page(
                "/ConfirmEmail",
                pageHandler: null,
                values: new { userId, code, Area = "Identity" },
                protocol: Request.Scheme);

            DisplayVerificationLink = true;
            VerificationLink = varificationLink;
           
            return Page();
        }
        
        public class InputModel
        {
            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Email is not a valid email address")]
            public string Email { get; set; }
        }
    }
}
