using Application.Common;
using Application.Subjects;
using Application.Data;
using Application.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Common;
using Web.Extensions;
using Application.TMS;
using Application.Users;

namespace Web.Pages.Admin
{
    public class OtherActivityAddModel : PageModel
    {
        private readonly GetAllUsersQuery getAllUsers;
        private readonly GetOtherActivityQuery getOtherActivityQuery;
        private readonly GetSubjectsLookup getSubjectsLookup;
        private readonly GetSubjectById getSubjectById;
        public OtherActivityAddModel(Providers providers)
        {
            Input = new OtherActivity();
            getAllUsers = new GetAllUsersQuery(providers);
            getOtherActivityQuery = new GetOtherActivityQuery(providers);
            Users = Enumerable.Empty<AppLookup>();
            getSubjectsLookup = new GetSubjectsLookup(providers);
            getSubjectById = new GetSubjectById(providers);
        }
        [BindProperty]
        public OtherActivity Input { get; set; }
        [BindNever]
        public IEnumerable<AppLookup> Users { get; set; }
        public IEnumerable<AppLookup> Subjects { get; set; }
        public void OnGet()
        {
            Users = getAllUsers.GetTutor(); 
            Subjects = getSubjectsLookup.ExecuteSync();
        }
        public IActionResult OnPost()
        {
            AppLookup user = getAllUsers.GetUserByUserId(Input.UserId);
            var subjects = getSubjectById.ExecuteSync(Input.SubjectId);
            Input.Users = user.Value;
            Input.Subject = subjects.Name;
            if (!ModelState.IsValid)
            {
                ModelState.Remove("Input.Subject");
                if (!ModelState.IsValid)
                    return Page();
            }
            var result = getOtherActivityQuery.ExecuteSync(Input);
            if (!result.IsSuccessful)
            {
                TempData[AppConstants.SuccessMessageKey] = result.Errors.Select(t => t.Message).FirstOrDefault();
                return RedirectToPage("/Admin/OtherActivityList");
                //ModelCourse.AddValidationErrors(result.Errors);
                //return Page();
            }
            TempData[AppConstants.SuccessMessageKey] = $"Course {Input.Users} is addedd";
            return RedirectToPage("/Admin/OtherActivityList");
        }
    }
}
