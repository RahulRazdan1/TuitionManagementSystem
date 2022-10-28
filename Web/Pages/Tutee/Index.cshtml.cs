using Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.SlotRequests;
using Web.Common;

namespace Web.Pages.Tutee
{
    public class IndexModel : PageModel
    {
        private readonly GetSlotRequestsQuery getSlotRequests;
        private readonly UserContext userContext;
        public IndexModel(Providers providers, UserContext userContext)
        {
            this.userContext = userContext;
            Input = new List<SlotRequest>();
            getSlotRequests = new GetSlotRequestsQuery(providers);
        }
        [BindProperty]
        public IList<SlotRequest> Input { get; set; }
        public async Task OnGetAsync()
        {
            long tuteeId = 0;
            if (userContext.IsAuthenticatedUser)
                if (userContext.Role.Name.ToUpper() != "SYSADMIN")
                    tuteeId = userContext.UserId;

            Input = getSlotRequests.ExecuteSync(tuteeId);
        }

    }

}
