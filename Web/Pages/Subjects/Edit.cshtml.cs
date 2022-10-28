using Application.Common;
using Application.Subjects;
using Application.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Common;
using Web.Extensions;

namespace Web.Pages.Subjects
{
    public class EditModel : PageModel
    {
        private readonly EditSubjectCommand editSubject;
        private readonly GetSubjectById getSubjectById;
        public EditModel(Providers providers)
        {
            Input = new Subject();
            editSubject = new EditSubjectCommand(providers);
            getSubjectById = new GetSubjectById(providers);
        }

        [BindProperty]
        public Subject Input { get; set; }

        public async void OnGet(long id)
        {
            var subject = getSubjectById.ExecuteSync(id);
            if (subject == null)
            {
                throw new InvalidOperationException($"Subject with id {id} does not exists");
            }
            Input = subject;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = editSubject.ExecuteSync(Input);
            if (!result.IsSuccessful)
            {
                ModelState.AddValidationErrors(result.Errors);
                return Page();
            }

            TempData[AppConstants.SuccessMessageKey] = $"Subject {Input.Name} is updated";
            return RedirectToPage("/Subjects/Index");
        }
    }
}
