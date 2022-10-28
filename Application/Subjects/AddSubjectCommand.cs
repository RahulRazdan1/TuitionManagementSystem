using Application.Common;

namespace Application.Subjects
{
    public class AddSubjectCommand : CommandAsync<Subject>
    {
        public AddSubjectCommand(Providers provider) : base(provider)
        {
        }

        public override async Task<ExecutionResult> ExecuteAsync(Subject input)
        {
            if (NameExists(input.Name, input.Id))
            {
                return ExecutionResult.Failure(new ValidationError($"{input.Name} is already added."));
            }
            await Providers.Database.Subjects.AddAsync(input);
            await Providers.Database.SaveChangesAsync();
            return ExecutionResult.Success();

        }

        public ExecutionResult ExecuteSync(Subject input)
        {
            if (NameExists(input.Name, input.Id))
            {
                return ExecutionResult.Failure(new ValidationError($"{input.Name} is already added."));
            }
            Providers.Database.Subjects.Add(input);
            Providers.Database.SaveChanges();
            return ExecutionResult.Success();

        }

        private bool NameExists(string name, long id)
        {
            return Providers.Database.Subjects.Any(x => x.Name == name && x.Id != id);
        }
    }
}
