using Application.TMS;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.Data;
using Application.Common;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Application.Identity;
using Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Web.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Application.Emails;


namespace Web.Areas.Identity.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly Register.Command Register;
        private readonly GetUserTypesLookup getUserTypes;
        private readonly IEmailer _emailer;

        public RegisterModel(Providers providers, UserManager<ApplicationUser> userManager, IEmailer emailer)
        {
            Register = new Register.Command(userManager, providers);
            getUserTypes = new GetUserTypesLookup(providers);

            Input = new Register.Input();
            UserTypes = Enumerable.Empty<AppLookup>();
            _emailer = emailer;
        }
        [BindProperty]
        public Register.Input Input { get; set; }
        [BindNever]
        public IEnumerable<AppLookup> UserTypes { get; set; }

        public async Task OnGetAsync()
        {
            UserTypes = getUserTypes.ExecuteSync();
        }
        public async Task<IActionResult> OnPost()
        {
            var result = Register.ExecuteSync(Input);
            if (!result.IsSuccessful)
            {
                ModelState.AddValidationErrors(result.Errors);
                UserTypes = getUserTypes.ExecuteSync();
                return Page();
            }
            ViewData[AppConstants.SuccessMessageKey] = "Register Confirmed";
            string body = "Hi " + Input.Name + ", <BR><BR>Thanks for registering with us. Use userId: " + Input.Email + " for login. <BR><BR>Thanks, <BR>Eagle Tutoring.";
            _emailer.TrySendEmail(Input.Email, "Eagle Tutoring Register Confirmed", body);
            return RedirectToPage("/Success");
            //return RedirectToPage("/RegistrationEmailConfirmation", new { email = Input.Email, Area = "Identity" });
        }
    }
}
