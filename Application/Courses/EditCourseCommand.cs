using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Courses
{
    public class EditCourseCommand : CommandAsync<Course>
    {
        public EditCourseCommand(Providers provider) : base(provider)
        {
        }

        public override async Task<ExecutionResult> ExecuteAsync(Course input)
        {
            if (NameExists(input.Name, input.Id, input.SubjectId))
            {
                return ExecutionResult.Failure(new ValidationError($"{input.Name} is already added."));
            }
            Providers.Database.Entry(input).State = EntityState.Modified;
            await Providers.Database.SaveChangesAsync();

            return ExecutionResult.Success();
        }

        public ExecutionResult ExecuteSync(Course input)
        {
            if (NameExists(input.Name, input.Id, input.SubjectId))
            {
                return ExecutionResult.Failure(new ValidationError($"{input.Name} is already added."));
            }
            Providers.Database.Entry(input).State = EntityState.Modified;
            Providers.Database.SaveChanges();

            return ExecutionResult.Success();
        }

        private bool NameExists(string name, long id, long subjectId)
        {
            return Providers.Database.Courses.Any(x => x.Name == name && x.Id != id && x.SubjectId == subjectId);
        }
    }
}
