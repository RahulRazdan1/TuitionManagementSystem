using Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.SlotRequests;

namespace Web.Pages.Tutor
{
    public class OpenSlotModel : PageModel
    {
        private readonly GetOpenSlotRequestsQuery getOpenSlotRequests;

        public OpenSlotModel(Providers providers)
        {
            Input = new List<SlotRequest>();
            getOpenSlotRequests = new GetOpenSlotRequestsQuery(providers);
        }
        [BindProperty]
        public IList<SlotRequest> Input { get; set; }
        public void OnGetAsync()
        {
            Input = getOpenSlotRequests.ExecuteSync(0, 0);
        }
    }
}
