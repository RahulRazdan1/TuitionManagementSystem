using Application.Common;
using Application.Subjects;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses
{
    public class GetCourseById : QueryAsync<long, Course>
    {
        public GetCourseById(Providers provider) : base(provider) { }
        public override async Task<Course> ExecuteAsync(long courseId)
        {
            var db = Providers.Database;
            return await (from c in db.Courses
                          join s in db.Subjects on c.SubjectId equals s.Id
                          where c.Id == courseId
                          select new Course
                          {
                              Id = c.Id,
                              Name = c.Name,
                              IsActive = c.IsActive,
                              Subject = new Subject { Name = s.Name },
                              SubjectId = c.SubjectId
                          }).AsNoTracking()
                         .FirstOrDefaultAsync();
        }

        public Course ExecuteSync(long courseId)
        {
            var db = Providers.Database;
            return (from c in db.Courses
                          join s in db.Subjects on c.SubjectId equals s.Id
                          where c.Id == courseId
                          select new Course
                          {
                              Id = c.Id,
                              Name = c.Name,
                              IsActive = c.IsActive,
                              Subject = new Subject { Name = s.Name },
                              SubjectId = c.SubjectId
                          }).AsNoTracking()
                         .FirstOrDefault();
        }
    }
}
