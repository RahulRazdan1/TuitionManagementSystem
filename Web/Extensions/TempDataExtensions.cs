using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Web.Common;

namespace Web.Extensions
{
    public static class TempDataExtensions
    {
        public static bool ContainsSuccessMessage(this ITempDataDictionary tempData)
        {
            return tempData.ContainsKey(AppConstants.SuccessMessageKey);
        }
        public static string GetSuccessMessage(this ITempDataDictionary tempData)
        {
            return tempData[AppConstants.SuccessMessageKey]?.ToString() ?? string.Empty ;
        }
        public static void SetSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            if (string.IsNullOrEmpty(message)) return;
             tempData[AppConstants.SuccessMessageKey] = message;
        }
    }
}
