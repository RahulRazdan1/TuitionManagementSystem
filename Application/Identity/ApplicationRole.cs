using Microsoft.AspNetCore.Identity;

namespace Application.Identity
{
    public class ApplicationRole : IdentityRole<long>
    {
        public string DisplayName { get; set; } = default!;
        public string HomePageUrl { get; set; } = default!;
        public bool IsDeletable { get; set; }
        public bool CanAccessEveryting { get; set; }
        public bool IsDefault { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
