using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Subjects
{
    public class GetSubjectsQuery : QueryAsync<IList<Subject>>
    {
        public GetSubjectsQuery(Providers provider) : base(provider)
        {
        }

        public override async Task<IList<Subject>> ExecuteAsync()
        {
            return await Providers.Database.Subjects.AsNoTracking().ToListAsync();
        }
        public IList<Subject> ExecuteSync()
        {
            return Providers.Database.Subjects.Where(t => t.IsActive == true).AsNoTracking().ToList();
        }
    }
}
