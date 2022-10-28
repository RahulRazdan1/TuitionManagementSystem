using Application.Common;

namespace Application.Courses
{
    public class AddCourseCommand : CommandAsync<Course>
    {
        public AddCourseCommand(Providers provider) : base(provider)
        {
        }

        public override async Task<ExecutionResult> ExecuteAsync(Course input)
        {
            if (NameExists(input.Name, input.Id, input.SubjectId))
            {
                return ExecutionResult.Failure(new ValidationError($"{input.Name} is already added."));
            }

            Providers.Database.Courses.Add(input);
            await Providers.Database.SaveChangesAsync();

            return ExecutionResult.Success();

        }

        public ExecutionResult ExecuteSync(Course input)
        {
            if (NameExists(input.Name, input.Id, input.SubjectId))
            {
                return ExecutionResult.Failure(new ValidationError($"{input.Name} is already added."));
            }

            input.Subject = null;
            Providers.Database.Courses.Add(input);
            Providers.Database.SaveChanges();

            return ExecutionResult.Success();

        }

        private bool NameExists(string name, long id, long subjectId)
        {
            return Providers.Database.Courses.Any(x => x.Name == name && x.Id != id && x.SubjectId == subjectId);
        }
    }
}
