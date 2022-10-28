using Application.Common;
using Application.Subjects;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses
{
    public class GetCourseQuery : QueryAsync<IList<Course>>
    {
        public GetCourseQuery(Providers provider) : base(provider) { }
        public override async Task<IList<Course>> ExecuteAsync()
        {
            var db = Providers.Database;
            return await (from c in db.Courses
                          join s in db.Subjects on c.SubjectId equals s.Id
                          select new Course
                          {
                              Id = c.Id,
                              Name = c.Name,
                              IsActive = c.IsActive,
                              Subject = new Subject { Name = s.Name }
                          }).ToListAsync();
        }

        public IList<Course> ExecuteSync()
        {
            var db = Providers.Database;
            return (from c in db.Courses
                    join s in db.Subjects on c.SubjectId equals s.Id
                    select new Course
                    {
                        Id = c.Id,
                        Name = c.Name,
                        IsActive = c.IsActive,
                        Subject = new Subject { Name = s.Name }
                    }).ToList();
        }
    }
}
