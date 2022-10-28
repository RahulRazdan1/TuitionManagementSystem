using Application.Common;
using Application.Subjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly GetSubjectsQuery getCountries;
        public IndexModel(Providers providers)
        {
            Input = new List<Subject>();
            getCountries = new GetSubjectsQuery(providers);
        }
        [BindProperty]
        public IList<Subject> Input { get; set; }
        public async Task OnGetAsync()
        {
            Input = getCountries.ExecuteSync();
        }
    }
}
