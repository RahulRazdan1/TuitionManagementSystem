using Application.Subjects;


namespace Application.Courses
{
    public class Course
    {
        public Course()
        {
            IsActive = true;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public long SubjectId { get; set; }        
        public Subject Subject { get; set; }
        public bool IsActive { get; set; }
    }
}
