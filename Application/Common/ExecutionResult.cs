namespace Application.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ExecutionResult
    {
        private readonly IList<ValidationError> errors;
        private readonly Dictionary<string, object> additionalData;
        private object value;
        private ExecutionResult()
        {
            this.errors = new List<ValidationError>();
            additionalData = new Dictionary<string, object>();
        }
        private ExecutionResult(IList<ValidationError> errors): this()
        {
            this.errors = errors;
        }
        private ExecutionResult(object value) : this()
        {
            value = value;
        }
        public bool IsSuccessful
        {
            get
            {
                return Errors == null || !Errors.Any();
            }
        }

        public IEnumerable<ValidationError> Errors { get { return errors; } }

        public TValue GetValue<TValue>() where TValue : class
        {
             return value as TValue;
           
        }
               
        public void AddAdditionalData(string key, object value)
        {
            if (additionalData.ContainsKey(key))
            {
                throw new InvalidOperationException($"Another value with key {key} already exists.");
            }

            additionalData.Add(key, value);
        }

        public TType GetAdditionalData<TType>(string key)
        {
            return (TType)additionalData[key];
        }
        public static ExecutionResult Success()
        {
            return new ExecutionResult();
        }
        public static ExecutionResult Success(object value)
        {
            return new ExecutionResult(value);
        }
        public static ExecutionResult Failure(IList<ValidationError> errors)
        {
            return new ExecutionResult(errors);
        }
        public static ExecutionResult Failure(ValidationError error)
        {
            return Failure(new List<ValidationError> { error });
        }
    }
   

}
