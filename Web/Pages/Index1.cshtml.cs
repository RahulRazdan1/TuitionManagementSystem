using Application.Emails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMS.Pages
{
    public class Index1Model : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmailer _emailer;

        public Index1Model(ILogger<IndexModel> logger, IEmailer emailer)
        {
            _logger = logger;
            _emailer = emailer;
            //_emailer.TrySendEmail("meet2vikas1234@gmail.com", "Test", "Sample Email");
        }

        public void OnGet()
        {
            RedirectToPage("/identity/login");
        }
    }
}