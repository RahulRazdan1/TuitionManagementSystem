using Microsoft.AspNetCore.Identity;

namespace Application.Identity
{
    public class ApplicationUser: IdentityUser<long>
    {
        public ApplicationUser()
        {
            MustChangePassword = false;
            IsActive = true;
            EmailConfirmed = true;
        }
        public string FullName { get; set; } = default!;
        public bool MustChangePassword { get; set; }
        public bool IsActive { get; set; }

    }
}
