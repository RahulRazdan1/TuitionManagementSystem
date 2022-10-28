using Application.Identity;

namespace Application.TMS
{
    public class UserDetail
    {
        public UserDetail()
        {
            User = new ApplicationUser();
        }
        public long Id { get; set; }
        public long UserTypeId { get; set; }
        public string? CompanyName { get; set; }
        public string? DotNumber { get; set; }
        public string? McNumber { get; set; }
        public long CountryId { get; set; }
        public long StateId { get; set; }
        public long CityId { get; set; }
        public long UserId { get; set; }
       
        public ApplicationUser User { get; set; }
    }
}
