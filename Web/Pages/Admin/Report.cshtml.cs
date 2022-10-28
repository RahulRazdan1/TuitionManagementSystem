using Application.Common;
using Application.TMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Admin
{
    public class ReportModel : PageModel
    {
        private readonly Report result;
        private readonly IConfiguration config;

        public ReportModel(Providers providers,IConfiguration configuration)
        {
            Input = new List<SlotResult>();
            result = new Report(providers);
            this.config = configuration;
        }
        [BindProperty]
        public IList<SlotResult> Input { get; set; }
        public async Task OnGetAsync()
        {
            Input = result.ExecuteSync(this.config.GetConnectionString("DefaultConnection"));
        }
    }
}
