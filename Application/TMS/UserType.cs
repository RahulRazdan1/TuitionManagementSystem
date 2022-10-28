namespace Application.TMS
{
    public class UserType
    {
        public UserType()
        {
            IsActive = true;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
