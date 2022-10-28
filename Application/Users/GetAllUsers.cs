using Application.Common;
using Microsoft.EntityFrameworkCore;
namespace Application.Users
{
    public class GetAllUsersQuery : QueryAsync<IList<UserListItem>>
    {
        public GetAllUsersQuery(Providers provider) : base(provider)
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
                select new
                {
                    User = user,
                    RoleName = role.Name
                }
               );
            var userDetails = await query.ToListAsync();
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

        public IList<AppLookup> ExecuteSync()
        {
            var db = Providers.Database;
            var query = (
                from user in db.Users.AsNoTracking()
                join userRole in db.UserRoles.AsNoTracking()
                on user.Id equals userRole.UserId into userRoleGroup
                from userRole in userRoleGroup.DefaultIfEmpty()
                join role in db.Roles.AsNoTracking() on userRole.RoleId equals role.Id
                where role.Name.ToUpper() != "SYSADMIN"
                select new
                {
                    User = user,
                    RoleName = role.Name
                }
               );
            var userDetails = query.ToList();
            var userListItems = new List<AppLookup>();
            foreach (var userDetail in userDetails)
            {
                var userListItem = userListItems.FirstOrDefault(
                    item => item.Key == userDetail.User.Id.ToString());
                if (userListItem == null)
                {
                    userListItem = new AppLookup
                    {
                        Key = userDetail.User.Id.ToString(),
                        Value = userDetail.User.FullName
                    };
                    userListItems.Add(userListItem);
                }
            }

            return userListItems;
        }

        public IList<AppLookup> GetTutor()
        {
            var db = Providers.Database;
            var query = (
                from user in db.Users.AsNoTracking()
                join userRole in db.UserRoles.AsNoTracking()
                on user.Id equals userRole.UserId into userRoleGroup
                from userRole in userRoleGroup.DefaultIfEmpty()
                join role in db.Roles.AsNoTracking() on userRole.RoleId equals role.Id
                where role.Name.ToUpper() == "TUTOR"
                select new
                {
                    User = user,
                    RoleName = role.Name
                }
               );
            var userDetails = query.ToList();
            var userListItems = new List<AppLookup>();
            foreach (var userDetail in userDetails)
            {
                var userListItem = userListItems.FirstOrDefault(
                    item => item.Key == userDetail.User.Id.ToString());
                if (userListItem == null)
                {
                    userListItem = new AppLookup
                    {
                        Key = userDetail.User.Id.ToString(),
                        Value = userDetail.User.FullName
                    };
                    userListItems.Add(userListItem);
                }
            }

            return userListItems;
        }

        public AppLookup GetUserByUserId(long UserId)
        {
            var db = Providers.Database;
            var query = (
                from user in db.Users.AsNoTracking()
                join userRole in db.UserRoles.AsNoTracking()
                on user.Id equals userRole.UserId into userRoleGroup
                from userRole in userRoleGroup.DefaultIfEmpty()
                join role in db.Roles.AsNoTracking() on userRole.RoleId equals role.Id
                where user.Id == UserId
                select new
                {
                    User = user,
                    RoleName = role.Name
                }
               );
            var userDetails = query.ToList();
            var userListItems = new List<AppLookup>();
            foreach (var userDetail in userDetails)
            {
                var userListItem = userListItems.FirstOrDefault(
                    item => item.Key == userDetail.User.Id.ToString());
                if (userListItem == null)
                {
                    userListItem = new AppLookup
                    {
                        Key = userDetail.User.Id.ToString(),
                        Value = userDetail.User.FullName
                    };
                    userListItems.Add(userListItem);
                }
            }

            return userListItems.FirstOrDefault();
        }
    }
}
