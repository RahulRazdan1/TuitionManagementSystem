using Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Identity
{
    public class ChangeStatusCommand : CommandAsync<long>
    {
        public ChangeStatusCommand(Providers provider) : base(provider)
        {
        }

        public override async Task<ExecutionResult> ExecuteAsync(long id)
        {
           var user = await Providers.Database.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user == null) throw new InvalidOperationException($"user with id {id} does not exist");
            user.IsActive = !user.IsActive;
            await Providers.Database.SaveChangesAsync();
            return ExecutionResult.Success();
        }
    }
}
