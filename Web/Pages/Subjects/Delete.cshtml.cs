using Application.Common;
using Application.Subjects;
using Application.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Common;
using Web.Extensions;

namespace Web.Pages.Subjects
{
    public class DeleteModel : PageModel
    {
        private readonly EditSubjectCommand editSubject;
        private readonly GetSubjectById getSubjectById;

        public DeleteModel(Providers providers)
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
            Input = subject;
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var subject = getSubjectById.ExecuteSync(Input.Id);
            Input = subject;
            Input.IsActive = false;
            var result = editSubject.ExecuteSync(Input);
            if (!result.IsSuccessful)
            {
                ModelState.AddValidationErrors(result.Errors);
                return Page();
            }
            TempData[AppConstants.SuccessMessageKey] = $"Subject {Input.Name} is deleted";
            return RedirectToPage("/Subjects/Index");
        }
    }
}
