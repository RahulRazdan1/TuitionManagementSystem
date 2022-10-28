namespace Application.Common
{
    public class EmptyValidator : IValidator<object>
    {
        public IList<ValidationError> Validate(object input)
        {
            return new List<ValidationError>();
        }
        public static EmptyValidator Instance { get { return new EmptyValidator(); } }
    }
}
