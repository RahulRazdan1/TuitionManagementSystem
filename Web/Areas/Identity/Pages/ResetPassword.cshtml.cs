#nullable disable

using Application.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Areas.Identity.Pages
{
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ResetPasswordModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }




        public IActionResult OnGet(string resetToken = null)
        {
            if (resetToken == null)
            {
                throw new InvalidOperationException("A code must be supplied for password reset.");
            }

            Input = new InputModel
            {
                Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(resetToken))
            };
            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
               return RedirectToPage("./ResetPasswordConfirmation");
            }

            var result = await userManager.ResetPasswordAsync(user, Input.Code, Input.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
                
            }
            return RedirectToPage("./ResetPasswordConfirmation");

        }

        public class InputModel
        {

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Email format is not valid")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }


            [DataType(DataType.Password)]
            [Display(Name = "Retype password")]
            [Compare("Password", ErrorMessage = "The password and retyped password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Validation code is required")]
            public string Code { get; set; }

        }
    }
}
