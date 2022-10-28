#nullable disable

using Application.Emails;
using Application.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;

namespace Web.Areas.Identity.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailer emailer;

        public ForgotPasswordModel(UserManager<ApplicationUser> userManager,
            IEmailer emailer)
        {
            this.userManager = userManager;
            this.emailer = emailer;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public bool ShowResetpasswordLink { get; set; }
        public bool ShowInValidEmailError { get; set; }
        public string Link { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await userManager.FindByEmailAsync(Input.Email);
            if (user == null || !user.EmailConfirmed)
            {
                ShowInValidEmailError = true;
                return Page();
            }

            var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
            resetToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(resetToken));

            var resetPasswordUrl = Url.Page("/ResetPassword",
                pageHandler: null,
                values: new { area = "Identity", resetToken },
                protocol: Request.Scheme);
            
            //ShowResetpasswordLink = true;
            //Link = resetPasswordUrl;
            //return Page();
            emailer.TrySendEmail(
                Input.Email,
                "Reset Password",
                $"Please reset your Eagle Tutoring account password by <a href='{HtmlEncoder.Default.Encode(resetPasswordUrl)}'>clicking here</a>. <BR><BR>Thanks,<BR>Eagle Tutoring");

            return RedirectToPage("./ForgotPasswordConfirmation");
        }

        public class InputModel
        {

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Email format is not valid")]
            public string Email { get; set; }
        }

    }
}
