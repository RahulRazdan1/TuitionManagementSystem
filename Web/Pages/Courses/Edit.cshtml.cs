using Application.Common;
using Application.Subjects;
using Application.Data;
using Application.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Common;
using Web.Extensions;

namespace Web.Pages.Courses
{
    public class EditModel : PageModel
    {
        private readonly EditCourseCommand editCourse;
        private readonly GetSubjectsLookup getSubjects;
        private readonly GetCourseById getCourseById;
        public EditModel(Providers providers)
        {
            Input = new Course();
            editCourse = new EditCourseCommand(providers);
            getSubjects = new GetSubjectsLookup(providers);
            getCourseById = new GetCourseById(providers);
        }
        [BindProperty]
        public Course Input { get; set; }

        [BindNever]
        public IEnumerable<AppLookup> Subjects { get; set; }
        public async Task OnGetAsync(long id)
        {

            var course = getCourseById.ExecuteSync(id);
            if (course == null)
            {
                throw new InvalidOperationException($"Course with id {id} does not exists");
            }
            Input = course;

            Subjects = getSubjects.ExecuteSync();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ModelState.Remove("Input.Subject");
                if (!ModelState.IsValid)
                    return Page();
            }
            var result = editCourse.ExecuteSync(Input);
            if (!result.IsSuccessful)
            {
                ModelState.AddValidationErrors(result.Errors);
                return Page();
            }
            TempData[AppConstants.SuccessMessageKey] = $"Course {Input.Name} is updated";
            return RedirectToPage("/Courses/Index");
        }

    }
}