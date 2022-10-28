using Application.Common;
using Application.SlotRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Common;
using Web.Extensions;

namespace Web.Pages.Tutee
{
    public class DeleteModel : PageModel
    {
        private readonly EditSlotRequestCommand editSlotRequest;
        private readonly GetSlotRequestById getSlotRequestById;
        private readonly UserContext userContext;
        public DeleteModel(Providers providers, UserContext userContext)
        {
            Input = new SlotRequest();
            editSlotRequest = new EditSlotRequestCommand(providers);
            getSlotRequestById = new GetSlotRequestById(providers);
            this.userContext = userContext;
        }
        [BindProperty]
        public SlotRequest Input { get; set; }

        public async void OnGet(long id)
        {
            var slotRequest = getSlotRequestById.ExecuteSync(id);
            Input = slotRequest;
        }

        public async Task<IActionResult> OnPostDelete()
        {
            Input.IsActive = false;
            Input.ModifiedBy = userContext.UserId;

            if (!ModelState.IsValid)
            {
                ModelState.Remove("Input.Id");
                ModelState.Remove("Input.Subject");
                ModelState.Remove("Input.Course");
                ModelState.Remove("Input.Topic");
                ModelState.Remove("Input.Tutee");
                ModelState.Remove("Input.Tutor");
                ModelState.Remove("Input.SlotTime1");
                ModelState.Remove("Input.SlotTime2");
                ModelState.Remove("Input.SlotTime3");
                if (!ModelState.IsValid)
                    return Page();
            }
            var result = editSlotRequest.ExecuteSyncDelete(Input);
            if (!result.IsSuccessful)
            {
                ModelState.AddValidationErrors(result.Errors);
                return Page();
            }
            TempData[AppConstants.SuccessMessageKey] = $"Slot Request is deleted";
            return RedirectToPage("/Tutee/Index");
        }
    }
}
