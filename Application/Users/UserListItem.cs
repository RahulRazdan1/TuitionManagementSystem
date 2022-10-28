namespace Application.Users
{
    public class UserListItem
    {
        public UserListItem()
        {
            Roles = new List<string>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public IList<string> Roles { get; set; }


    }
}
