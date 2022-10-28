namespace Application.Common
{
    public abstract class Command<TInput>: CommandQueryBase
    {
        public Command(Providers providers):base(providers) {}
        public abstract ExecutionResult Execute(TInput input);
    }
   
    public abstract class CommandAsync<TInput>: CommandQueryBase
    {
        public CommandAsync(Providers provider):base(provider){}
        public abstract Task<ExecutionResult> ExecuteAsync(TInput input);
    }
    
}
