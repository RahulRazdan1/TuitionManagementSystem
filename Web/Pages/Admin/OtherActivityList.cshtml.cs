using Application.Common;
using Application.TMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Admin
{
    public class OtherActivityListModel : PageModel
    {
        private readonly IConfiguration config;
        public OtherActivityListModel(Providers providers, IConfiguration configuration)
        {
            Input = new List<OtherActivity>();
            this.config = configuration;
        }
        [BindProperty]
        public IList<OtherActivity> Input { get; set; }
        public Task OnGetAsync()
        {
            Input = GetOtherActivityQuery.GetOtherActivityList(config.GetConnectionString("DefaultConnection"));
            return Task.CompletedTask;
        }
    }
}
