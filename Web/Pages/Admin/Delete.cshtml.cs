using Application.Common;
using Application.Emails;
using Application.SlotRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Common;
using Web.Extensions;

namespace Web.Pages.Admin
{
    public class SlotDetailDeleteModel : PageModel
    {
        private readonly EditSlotRequestCommand editSlotRequest;
        private readonly GetSlotRequestById getSlotRequestById;
        private readonly UserContext userContext;
        private readonly IEmailer _emailer;
        public SlotDetailDeleteModel(Providers providers, UserContext userContext, IEmailer emailer)
        {
            Input = new SlotRequest();
            editSlotRequest = new EditSlotRequestCommand(providers);
            getSlotRequestById = new GetSlotRequestById(providers);
            this.userContext = userContext;
            _emailer = emailer;
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

            var SlotRequest = getSlotRequestById.ExecuteSync(Input.Id);

            string body = "Hi " + SlotRequest.Tutee.Name + ", <BR/>The slot request of subject " + SlotRequest.Subject.Name +
                          " with course " + SlotRequest.Course.Name + " is deleted by admin.<BR/>" +
                          " Slot time is :" + SlotRequest.AcceptedSlotTime + " on Date :" + SlotRequest.Date.ToShortDateString() + ". <BR/>Thanks, <BR/>Eagle Tutoring.";
            _emailer.TrySendEmail(SlotRequest.Tutee.Email, "Eagle Tutoring Slot Canceled", body);

            body = "Hi " + SlotRequest.Tutor.Name + ", <BR/>The slot request of subject " + SlotRequest.Subject.Name +
                          " with course " + SlotRequest.Course.Name + " is deleted by admin.<BR/>" +
                          " Slot time is :" + SlotRequest.AcceptedSlotTime + " on Date :" + SlotRequest.Date.ToShortDateString() + ". <BR/>Thanks, <BR/>Eagle Tutoring.";
            _emailer.TrySendEmail(SlotRequest.Tutor.Email, "Eagle Tutoring Slot Canceled", body);


            return RedirectToPage("/Admin/SlotDetail");
        }
    }
}
