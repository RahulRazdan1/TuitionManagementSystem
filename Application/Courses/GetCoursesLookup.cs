using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses
{
    public class GetCoursesLookup : QueryAsync<long?, IEnumerable<AppLookup>>
    {
        public GetCoursesLookup(Providers provider) : base(provider) { }

        public override async Task<IEnumerable<AppLookup>> ExecuteAsync(long? subjectId)
        {
            if (!subjectId.HasValue)
            {
                return new List<AppLookup>();
            }
            return await Providers.Database.Courses
                .Where(course => (course.SubjectId == subjectId.Value) && course.IsActive)
                .Select(course => new AppLookup
                {
                    Key = course.Id.ToString(),
                    Value = course.Name
                })
                .ToListAsync();
        }

        public IEnumerable<AppLookup> ExecuteSync(long? subjectId)
        {
            if (!subjectId.HasValue)
            {
                return new List<AppLookup>();
            }
            return Providers.Database.Courses
                .Where(course => (course.SubjectId == subjectId.Value) && course.IsActive)
                .Select(course => new AppLookup
                {
                    Key = course.Id.ToString(),
                    Value = course.Name
                })
                .ToList();
        }
    }
}
