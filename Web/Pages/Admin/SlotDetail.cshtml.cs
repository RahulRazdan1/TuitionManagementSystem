using Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.SlotRequests;

namespace Web.Pages.Admin
{
    public class SlotDetailModel : PageModel
    {
        
        private readonly GetSlotRequestsQuery getSlotRequests;       

        public SlotDetailModel(Providers providers)
        {
            Input = new List<SlotRequest>();
            getSlotRequests = new GetSlotRequestsQuery(providers);
        }
        [BindProperty]
        public IList<SlotRequest> Input { get; set; }
        public async Task OnGetAsync()
        {
            long userId = 0;
            Input = getSlotRequests.ExecuteSync(userId);
        }
    }
}
