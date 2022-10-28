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
    public class AddModel : PageModel
    {
        private readonly AddCourseCommand addCourseCommand;
        private readonly GetSubjectsLookup getSubjectsLookup;
        private readonly GetSubjectById getSubjectById;
        public AddModel(Providers providers)
        {
            Input = new Course();
            getSubjectsLookup = new GetSubjectsLookup(providers);
            addCourseCommand = new AddCourseCommand(providers);
            getSubjectById = new GetSubjectById(providers);
        }
        [BindProperty]
        public Course Input { get; set; }
        [BindNever]
        public IEnumerable<AppLookup> Subjects { get; set; }
        public void OnGet()
        {
            Subjects = getSubjectsLookup.ExecuteSync();

            var Subject = Subjects.FirstOrDefault();

        }
        public async Task<IActionResult> OnPost()
        {
            var Subject = getSubjectById.ExecuteSync(Input.SubjectId);
            Input.Subject = Subject;
            if (!ModelState.IsValid)
            {
                ModelState.Remove("Input.Subject");
                if (!ModelState.IsValid)
                    return Page();
            }
            var result = addCourseCommand.ExecuteSync(Input);
            if (!result.IsSuccessful)
            {
                TempData[AppConstants.SuccessMessageKey] = result.Errors.Select(t => t.Message).FirstOrDefault();
                return RedirectToPage("/Courses/Index");
                //ModelCourse.AddValidationErrors(result.Errors);
                //return Page();
            }
            TempData[AppConstants.SuccessMessageKey] = $"Course {Input.Name} is addedd";
            return RedirectToPage("/Courses/Index");
        }
    }
}
