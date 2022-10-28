using Application.Common;
using Application.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Web.Common;

namespace Web.Areas.Identity.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly UserContext userContext;
        private readonly GetUserFirstRole getUserFirstRole;

        public LoginModel(
            Providers providers,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            UserContext userContext
           )
        {
            
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userContext = userContext;
            getUserFirstRole = new GetUserFirstRole(providers);
            Input = new InputModel();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; } = default!;


        public async Task OnGetAsync(string? returnUrl = null)
        {
            userContext.SignOut();
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid Email/Password");
                return Page();
            }

            var result = await signInManager.PasswordSignInAsync(user, Input.Password,
                false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                if (!user.EmailConfirmed)
                {
                    return RedirectToPage("/ResendEmailConfirmation", new { Area = "Identity" });
                }

                if (result.IsLockedOut)
                {
                    return RedirectToPage("/Lockout", new { Area = "Identity" });
                }

                ModelState.AddModelError(string.Empty, "Invalid Email/Password");

                return Page();
            }

            if (!user.IsActive)
            {
                return RedirectToPage("VerificationPending", new { Area = "Identity" });
            }
            var firstRole = await getUserFirstRole.ExecuteAsync(user.Id);
             
            userContext.SetSignInDetail(user.Id, user.UserName);
            userContext.SetRole(firstRole);
            userContext.Name = user.FullName;

            return LocalRedirect(GetPageToRedirect(firstRole, returnUrl));

        }
     
        private static string GetPageToRedirect(ApplicationRole role, string? returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return returnUrl;
            }
            return role.HomePageUrl;
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Email is not a valid email address")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            public string? Password { get; set; }

        }

    }

}

