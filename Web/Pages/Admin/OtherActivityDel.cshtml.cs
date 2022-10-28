using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.Common;
using Application.TMS;
using Web.Common;
using Web.Extensions;

namespace Web.Pages.Admin
{
   
    public class OtherActivityDelModel : PageModel
    {
        private readonly GetOtherActivityQuery getOtherActivityQuery;
        private readonly UserContext userContext;
        public OtherActivityDelModel(Providers providers, UserContext userContext)
        {
            Input = new OtherActivity();
            getOtherActivityQuery = new GetOtherActivityQuery(providers);
            this.userContext = userContext;
        }
        [BindProperty]
        public OtherActivity Input { get; set; }

        public async void OnGet(long id)
        {
            var otherActivity = getOtherActivityQuery.otherActivityById(id);
            Input = otherActivity;
        }

        public async Task<IActionResult> OnPostDelete()
        {
            Input.IsActive = false;
            var result = getOtherActivityQuery.DeleteExecuteSync(Input);
            if (!result.IsSuccessful)
            {
                ModelState.AddValidationErrors(result.Errors);
                return Page();
            }
            TempData[AppConstants.SuccessMessageKey] = $"Other Activity is deleted";
            return RedirectToPage("/Admin/OtherActivityList");
        }
    }
}
