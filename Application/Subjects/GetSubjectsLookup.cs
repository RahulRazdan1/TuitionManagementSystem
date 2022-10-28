using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Subjects
{
    public class GetSubjectsLookup : QueryAsync<IEnumerable<AppLookup>>
    {
        public GetSubjectsLookup(Providers provider) : base(provider)
        {
        }

        public override async Task<IEnumerable<AppLookup>> ExecuteAsync()
        {
            return await Providers.Database.Subjects.
                Where(subject => subject.IsActive)
                .Select(subject => new AppLookup
                {
                    Key = subject.Id.ToString(),
                    Value = subject.Name
                })
                .ToListAsync();
        }

        public IEnumerable<AppLookup> ExecuteSync()
        {
            return  Providers.Database.Subjects.
                Where(subject => subject.IsActive)
                .Select(subject => new AppLookup
                {
                    Key = subject.Id.ToString(),
                    Value = subject.Name
                })
                .ToList();
        }
    }
}
