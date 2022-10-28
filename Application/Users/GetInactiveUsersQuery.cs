using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public class GetInactiveUsersQuery : QueryAsync<IList<UserListItem>>
    {
        public GetInactiveUsersQuery(Providers provider) : base(provider)
        {
        }

        public override async Task<IList<UserListItem>> ExecuteAsync()
        {
            var db = Providers.Database;
            var query = (
               from user in db.Users.AsNoTracking()
               join userRole in db.UserRoles.AsNoTracking()
               on user.Id equals userRole.UserId into userRoleGroup
               from userRole in userRoleGroup.DefaultIfEmpty()
               join role in db.Roles.AsNoTracking() on userRole.RoleId equals role.Id
               where user.IsActive == false
               select new
               {
                   User = user,
                   RoleName = role.Name
               }
              );
            var userDetails = await query.AsNoTracking().ToListAsync();
            var userListItems = new List<UserListItem>();
            foreach (var userDetail in userDetails)
            {
                var userListItem = userListItems.FirstOrDefault(
                    item => item.Id == userDetail.User.Id);
                if (userListItem == null)
                {
                    userListItem = new UserListItem
                    {
                        Id = userDetail.User.Id,
                        Name = userDetail.User.FullName,
                        Email = userDetail.User.Email
                    };
                    userListItems.Add(userListItem);
                }
                if (!string.IsNullOrEmpty(userDetail.RoleName))
                {
                    userListItem.Roles.Add(userDetail.RoleName);
                }

            }

            return userListItems;
        }
    }
}
