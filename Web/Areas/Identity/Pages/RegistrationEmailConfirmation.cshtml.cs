#nullable disable

using Application.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace Web.Areas.Identity.Pages
{
    [AllowAnonymous]
    public class RegistrationEmailConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
      
        public RegistrationEmailConfirmationModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            
        }

        public string Email { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return RedirectToPage("/Index");
            }

            var user = await this.userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to get user with email '{email}'.");
            }

            Email = email;
            var userId = await userManager.GetUserIdAsync(user);
            var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var emailConfirmationURL = Url.Page(
                "/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId, code = code },
                protocol: Request.Scheme);
            
            //TODO: Once you add a real email sender, you should remove this code that lets you confirm the account
            
            DisplayConfirmAccountLink = true;
            EmailConfirmationUrl = emailConfirmationURL;

            return Page();
        }
    }
}
