namespace Application.Common
{
    public interface IValidator<TInput>
    {
        public IList<ValidationError> Validate(TInput input);
    }
}
