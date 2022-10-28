using Application.Common;
using Application.Emails;
using Application.SlotRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Common;
using Web.Extensions;

namespace Web.Pages.Tutor
{
    public class AcceptSlotModel : PageModel
    {
        private readonly EditSlotRequestCommand editSlotRequest;
        private readonly UserContext userContext;
        private readonly IEmailer _emailer;
        private readonly GetSlotTimeBySlotId getSlotTimeBySlotId;
        private readonly GetSlotRequestById getSlotRequestById;
        private readonly GetSlotTimeById getSlotTime;


        public AcceptSlotModel(Providers providers, UserContext userContext, IEmailer emailer)
        {
            Input = new SlotRequest();
            editSlotRequest = new EditSlotRequestCommand(providers);
            getSlotTimeBySlotId = new GetSlotTimeBySlotId(providers);
            getSlotRequestById = new GetSlotRequestById(providers);
            getSlotTime = new GetSlotTimeById(providers);
            this.userContext = userContext;
            _emailer = emailer;
        }
        [BindProperty]
        public SlotRequest Input { get; set; }

        [BindNever]
        public IEnumerable<AppLookup> SlotTimes { get; set; }
        public async Task OnGetAsync(long id)
        {
            SlotTimes = getSlotTimeBySlotId.ExecuteSync(id);
            var SlotRequest = getSlotRequestById.ExecuteSync(id);
            if (SlotRequest == null)
            {
                throw new InvalidOperationException($"Slot Request with id {id} does not exists");
            }
            Input = SlotRequest;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var AcceptedSlotTime = getSlotTime.ExecuteSync(Convert.ToInt64(Input.AcceptedSlotTime));
            Input.AcceptedSlotTime = AcceptedSlotTime.Name;
            Input.TutorId = userContext.UserId;
            Input.IsActive = true;            
            var result = editSlotRequest.ExecuteSync(Input);
            if (!result.IsSuccessful)
            {
                ModelState.AddValidationErrors(result.Errors);
                return Page();
            }
            var SlotRequest = getSlotRequestById.ExecuteSync(Input.Id);
            TempData[AppConstants.SuccessMessageKey] = $"Slot Request {SlotRequest.Tutee.Name} is Accept.";

            string body = "Hi " + SlotRequest.Tutee.Name + ", <BR/>The slot request of subject " + SlotRequest.Subject.Name + 
                          " with course " + SlotRequest.Course.Name + " is accepted by " + SlotRequest.Tutor.Name + 
                          " and accepted time is :" + SlotRequest.AcceptedSlotTime + " on Date :" + SlotRequest.Date.ToShortDateString() + ". <BR/>Thanks, <BR/>Eagle Tutoring.";
            _emailer.TrySendEmail(SlotRequest.Tutee.Email, "Eagle Tutoring Slot Accepted", body);

            body = "Hi " + SlotRequest.Tutor.Name + ", <BR/>The slot request of subject " + SlotRequest.Subject.Name +
                          " with course " + SlotRequest.Course.Name + " is accepted by you.<BR/>" +
                          " Accepted time is :" + SlotRequest.AcceptedSlotTime + " on Date :" + SlotRequest.Date.ToShortDateString() + ". <BR/>Thanks, <BR/>Eagle Tutoring.";
            _emailer.TrySendEmail(SlotRequest.Tutor.Email, "Eagle Tutoring Slot Accepted", body);


            return RedirectToPage("/Tutor/Index");
        }
    }
}
