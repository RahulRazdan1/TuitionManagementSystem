using Application.Common;
using Application.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly GetCourseQuery getCourses;
        public IndexModel(Providers providers)
        {
            Input = new List<Course>();
            getCourses = new GetCourseQuery(providers);
        }
        [BindProperty]
        public IList<Course> Input { get; set; }
        public void OnGetAsync()
        {
            Input = getCourses.ExecuteSync();
        }

    }

}
