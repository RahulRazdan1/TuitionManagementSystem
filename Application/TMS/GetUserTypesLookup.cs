
using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.TMS
{
    public class GetUserTypesLookup : QueryAsync<IEnumerable<AppLookup>>
    {
        public GetUserTypesLookup(Providers provider) : base(provider) { }


        public override async Task<IEnumerable<AppLookup>> ExecuteAsync()
        {
            return await Providers.Database.UserTypes.
                Where(country => country.IsActive)
                .Select(country => new AppLookup
                {
                    Key = country.Id.ToString(),
                    Value = country.Name
                })
                .ToListAsync();
        }

        public IEnumerable<AppLookup> ExecuteSync()
        {
            return Providers.Database.UserTypes.
                Where(country => country.IsActive)
                .Select(country => new AppLookup
                {
                    Key = country.Id.ToString(),
                    Value = country.Name
                })
                .ToList();
        }
    }
}
