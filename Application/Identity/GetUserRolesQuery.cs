using Application.Common;

namespace Application.Identity
{
    public class GetUserRolesQuery : QueryAsync<long, AppLookup>
    {
        public GetUserRolesQuery(Providers provider) : base(provider)
        {
        }

        public override Task<AppLookup> ExecuteAsync(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
