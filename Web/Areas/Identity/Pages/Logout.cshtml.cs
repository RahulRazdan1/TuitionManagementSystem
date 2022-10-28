
#nullable disable

using Application.Common;
using Application.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Common;

namespace Web.Areas.Identity.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public LogoutModel(
            SignInManager<ApplicationUser> signInManager,
            UserContext userContext)
        {
            this.signInManager = signInManager;
            this.UserContext = userContext;
        }

        public UserContext UserContext
        {
            get; private set;
        }
       
        public async Task<IActionResult> OnPost()
        {
            await signInManager.SignOutAsync();
            UserContext.SignOut();
            return RedirectToPage();
            
        }
    }
}
