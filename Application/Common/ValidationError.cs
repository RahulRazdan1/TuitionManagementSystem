namespace Application.Common
{
    public class ValidationError
    {
        public ValidationError(string message) : this(string.Empty, message)
        {

        }
        public ValidationError(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }
        public string PropertyName { get; private set; }
        public string Message { get; private set; }
    }
}
