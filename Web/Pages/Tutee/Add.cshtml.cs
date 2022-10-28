using Application.Common;
using Application.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Common;
using Web.Extensions;
using Application.Subjects;
using Application.Courses;
using Application.SlotRequests;
using Application.Emails;

namespace Web.Pages.Tutee
{
    public class AddModel : PageModel
    {
        private readonly AddSlotRequestCommand addSlotRequestCommand;
        private readonly GetSubjectsLookup getSubjects;
        private readonly GetCoursesLookup getCourses;
        private readonly GetSlotTimesLookUp getSlotTimes;
        private readonly GetSlotTimeById getSlotTime;
        private readonly UserContext userContext;
        private readonly IEmailer _emailer;

        private readonly GetSubjectById getSubjectById;
        private readonly GetCourseById getCourseById;
        public AddModel(Providers providers, UserContext userContext, IEmailer emailer)
        {
            this.userContext = userContext;
            addSlotRequestCommand = new AddSlotRequestCommand(providers);
            getSubjects = new GetSubjectsLookup(providers);
            getCourses = new GetCoursesLookup(providers);
            getSlotTimes = new GetSlotTimesLookUp(providers);
            getSlotTime = new GetSlotTimeById(providers);
            getSubjectById = new GetSubjectById(providers);
            getCourseById = new GetCourseById(providers);

            Input = new SlotRequest();
            Input.Date = DateTime.Now;
            Subjects = Enumerable.Empty<AppLookup>();
            Courses = Enumerable.Empty<AppLookup>();
            SlotTimes = Enumerable.Empty<AppLookup>(); 
            _emailer = emailer;
        }

        [BindProperty]
        public SlotRequest Input { get; set; }
        [BindNever]
        public IEnumerable<AppLookup> Subjects { get; set; }
        [BindNever]
        public IEnumerable<AppLookup> Courses { get; set; }
        [BindNever]
        public IEnumerable<AppLookup> SlotTimes { get; set; }


        public void OnGetAsync()
        {
            Subjects = getSubjects.ExecuteSync();
            SlotTimes = getSlotTimes.ExecuteSync();
        }
        public JsonResult OnGetCoursesAsync(long subjectId)
        {
            return new JsonResult(getCourses.ExecuteSync(subjectId));
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.Remove("Input.Subject");
                ModelState.Remove("Input.Course");
                ModelState.Remove("Input.Tutee");
                ModelState.Remove("Input.Tutor");
                if (!ModelState.IsValid)
                    return Page();
            }

            long userId = 0;
            if (userContext.IsAuthenticatedUser)
                if (userContext.Role.Name.ToUpper() != "SYSADMIN")
                    userId = userContext.UserId;

            var subject = getSubjectById.ExecuteSync(Convert.ToInt64(Input.SubjectId));
            var course = getCourseById.ExecuteSync(Convert.ToInt64(Input.CourseId));
            var SlotTime1 = getSlotTime.ExecuteSync(Convert.ToInt64(Input.SlotTime1));
            var SlotTime2 = getSlotTime.ExecuteSync(Convert.ToInt64(Input.SlotTime2));
            var SlotTime3 = getSlotTime.ExecuteSync(Convert.ToInt64(Input.SlotTime3));

            Input.SlotTime1 = SlotTime1.Name;
            Input.SlotTime2 = SlotTime2.Name;
            Input.SlotTime3 = SlotTime3.Name;
            Input.TuteeId = userId;

            if (userId == 0)
            {
                TempData[AppConstants.SuccessMessageKey] = $"You can't add SlotRequest";
                return RedirectToPage("/Tutee/Index");
            }

            var result = addSlotRequestCommand.ExecuteSync(Input);
            if (!result.IsSuccessful)
            {
                TempData[AppConstants.SuccessMessageKey] = result.Errors.Select(t => t.Message).FirstOrDefault();
                return RedirectToPage("/Tutee/Index");
                //ModelSlotRequest.AddValidationErrors(result.Errors);
                //return Page();
            }
            TempData[AppConstants.SuccessMessageKey] = $"SlotRequest is added";
                       
            string body = "Hi " + userContext.Name + ", <BR/><BR/>The slot request of subject " + subject.Name +
                          " with course " + course.Name + " is added by you. <BR/>" +
                          " On Date : " + Input.Date.ToShortDateString() + " <BR/>" +
                          " Slot Time1: " + Input.SlotTime1 + " <BR/>" +
                          " Slot Time2: " + Input.SlotTime2 + " <BR/>" +
                          " Slot Time3: " + Input.SlotTime3 + ". <BR/>" +
                          " <BR/>Thanks, <BR/>Eagle Tutoring.";
            _emailer.TrySendEmail(userContext.UserName, "Slot Request is added", body);
            return RedirectToPage("/Tutee/Index");
        }


    }
}
