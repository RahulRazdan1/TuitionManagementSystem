namespace Application.Common
{
    public interface ICommand<TInput>
    {
        ExecutionResult Execute(TInput input);
    }
}