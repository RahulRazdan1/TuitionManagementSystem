using Application.Common;
using Application.Subjects;
using Application.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Common;
using Web.Extensions;

namespace Web.Pages.Subjects
{
    public class AddModel : PageModel
    {
        private readonly AddSubjectCommand addSubject;
        public AddModel(Providers providers)
        {
            Input = new Subject();
            addSubject = new AddSubjectCommand(providers);
        }

        [BindProperty]
        public Subject Input { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = addSubject.ExecuteSync(Input);
            if (!result.IsSuccessful)
            {
                ModelState.AddValidationErrors(result.Errors);
                return Page();
            }

            TempData[AppConstants.SuccessMessageKey] = $"Subject {Input.Name} is addedd";
            return RedirectToPage("/Subjects/Index");
        }
    }
}
