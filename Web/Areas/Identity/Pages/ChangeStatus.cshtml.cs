using Application.Common;
using Application.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Common;

namespace Web.Areas.Identity.Pages
{
    public class ChangeStatusModel : PageModel
    {
        private readonly ChangeStatusCommand changeStatus;
        public ChangeStatusModel(Providers providers)
        {
            changeStatus = new ChangeStatusCommand(providers);
        }
        public  async Task OnPostAsync(long profileId)
        {
            await changeStatus.ExecuteAsync(profileId);
            TempData[AppConstants.SuccessMessageKey] = "Status has been changed";
        }
    }
}
