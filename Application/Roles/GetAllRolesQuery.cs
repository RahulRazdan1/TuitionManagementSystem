using Application.Common;
using Application.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Roles
{
    public class GetAllRolesQuery : QueryAsync<List<ApplicationRole>>
    {
        public GetAllRolesQuery(Providers provider) : base(provider)
        {
        }

        public override async Task<List<ApplicationRole>> ExecuteAsync()
        {
           return await Providers.Database.Roles.AsNoTracking().ToListAsync();
        }
    }
}
