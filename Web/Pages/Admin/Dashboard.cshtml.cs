using Application.Common;
using Application.TMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Common;

namespace Web.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly UserContext userContext;

        [BindProperty]
        public DashBoard Input { get; set; }

        public DashboardModel(Providers providers, UserContext userContext)
        {
            this.userContext = userContext;
            Input = new DashBoard(userContext.UserId, providers);
        }
        public void OnGet()
        {
        }
    }
}
