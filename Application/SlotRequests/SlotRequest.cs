using Application.Subjects;
using Application.Courses;
using System.ComponentModel.DataAnnotations;
using Application.Users;

namespace Application.SlotRequests
{
    public class SlotRequest
    {
        public SlotRequest()
        {
            IsActive = true;
        }
        public long Id { get; set; }
        public AspNetUser Tutee { get; set; }
        public long TuteeId { get; set; }
        public Subject Subject { get; set; }
        public long SubjectId { get; set; }
        public Course Course { get; set; }
        public long CourseId { get; set; }
        public string Topic { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Slot Time 1 is required")]
        [Display(Name = "Slot Time 1")]
        public string SlotTime1 { get; set; }

        [Required(ErrorMessage = "Slot Time 2 is required")]
        [Display(Name = "Slot Time 2")]
        public string SlotTime2 { get; set; }

        [Required(ErrorMessage = "Slot Time 3 is required")]
        [Display(Name = "Slot Time 3")]
        public string SlotTime3 { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public AspNetUser Tutor { get; set; }
        public long? TutorId { get; set; }

        [Display(Name = "Accept Slot Time")]
        public string? AcceptedSlotTime { get; set; }
        public DateTime? AcceptedOn { get; set; }
    }
}
