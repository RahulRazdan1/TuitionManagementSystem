namespace Application.Subjects
{
    public class Subject
    {
        public Subject()
        {
            IsActive = true;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
