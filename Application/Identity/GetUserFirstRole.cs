using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Identity
{
    public class GetUserFirstRole : QueryAsync<long, ApplicationRole>
    {
        public GetUserFirstRole(Providers provider) : base(provider)
        {
        }

        public override async Task<ApplicationRole> ExecuteAsync(long userId)
        {
            var db = Providers.Database;
            var firstRoleQuery = db.Users
                .Where(user => user.Id == userId)
                .Join(db.UserRoles,
                   user => user.Id,
                   userRole => userRole.UserId,
                   (user, userRole) => userRole.RoleId
                   )
                .Join(db.Roles,
                   userRoleId => userRoleId,
                   role => role.Id,
                   (userRoleId, role) => role
                   )
                  .Select(role => new ApplicationRole
                  {
                      Id = role.Id,
                      Name = role.Name,
                      DisplayName = role.DisplayName,
                      HomePageUrl = role.HomePageUrl,
                  });

            var firstRole = await firstRoleQuery.AsNoTracking().FirstOrDefaultAsync();

            if (firstRole == null)
            {
                return new ApplicationRole { Name = "Default", DisplayName = "Default", HomePageUrl = "/Identity/NoRoleAssigned" };

            }
            return firstRole;

        }

    }
}
