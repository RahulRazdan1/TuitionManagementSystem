using Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.SlotRequests;
using Web.Common;

namespace Web.Pages.Tutor
{
    public class AcceptedSlotModel : PageModel
    {
        private readonly GetSlotRequestsQuery getSlotRequests;
        private readonly UserContext userContext;

        public AcceptedSlotModel(Providers providers, UserContext userContext)
        {
            this.userContext = userContext;
            Input = new List<SlotRequest>();
            getSlotRequests = new GetSlotRequestsQuery(providers);
        }
        [BindProperty]
        public IList<SlotRequest> Input { get; set; }
        public async Task OnGetAsync()
        {
            long tuteeId = 0, tutorId = 0;

            if (userContext.IsAuthenticatedUser)
                if (userContext.Role.Name.ToUpper() != "SYSADMIN")
                    tutorId = userContext.UserId;

            Input = getSlotRequests.ExecuteSync(tuteeId, tutorId);
        }
    }
}
