using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Subjects
{
    public class GetSubjectById : QueryAsync<long, Subject>
    {
        public GetSubjectById(Providers provider) : base(provider)
        {
        }

        public override async Task<Subject> ExecuteAsync(long subjectId)
        {
            var db = Providers.Database;
            return await (from s in db.Subjects
                          where s.Id == subjectId
                          select new Subject
                          {
                              Id = s.Id,
                              Name = s.Name,
                              IsActive = s.IsActive
                          }).AsNoTracking()
                         .FirstOrDefaultAsync();
        }

        public Subject ExecuteSync(long subjectId)
        {
            var db = Providers.Database;
            return (from s in db.Subjects
                    where s.Id == subjectId
                    select new Subject
                    {
                        Id = s.Id,
                        Name = s.Name,
                        IsActive = s.IsActive
                    }).AsNoTracking()
                         .FirstOrDefault();
        }
    }
}
