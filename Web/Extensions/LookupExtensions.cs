using Microsoft.AspNetCore.Mvc.Rendering;
using Application.Common;

namespace Web.Extensions
{
    public static class LookupExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectItems(this IEnumerable<AppLookup> lookups)
        {
            if (lookups == null)
                lookups = Enumerable.Empty<AppLookup>();

            return lookups.Select(lookup => new SelectListItem(lookup.Value, lookup.Key));

        }
    }
}
