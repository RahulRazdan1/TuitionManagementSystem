using Application.Data;
using Application.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.Common;
using Web.Common;
using Web.Extensions;

namespace Web.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly EditCourseCommand editCourse;
        private readonly GetCourseById getCourseById;
        public DeleteModel(Providers providers)
        {
            Input = new Course();
            editCourse = new EditCourseCommand(providers);
            getCourseById = new GetCourseById(providers);
        }
        [BindProperty]
        public Course Input { get; set; }

        public async void OnGet(long id)
        {
            var subject = getCourseById.ExecuteSync(id);
            Input = subject;
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var course = getCourseById.ExecuteSync(Input.Id);
            Input = course;
            Input.IsActive = false;

            if (!ModelState.IsValid)
            {
                ModelState.Remove("Input.Id");
                ModelState.Remove("Input.Name");
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
            TempData[AppConstants.SuccessMessageKey] = $"Course {Input.Name} is deleted";
            return RedirectToPage("/Courses/Index");            
        }
    }
}
