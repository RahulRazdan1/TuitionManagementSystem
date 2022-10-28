using Application.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Web.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddValidationErrors(this ModelStateDictionary modelState, IEnumerable<ValidationError> errors)
        {
            foreach (var error in errors)
            {
                modelState.AddModelError(error.PropertyName, error.Message);
            }

        }
    }
}
