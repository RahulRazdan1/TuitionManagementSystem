using Application.Common;
using Application.Data;
using Application.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Users
{
    public class InactiveModel : PageModel
    {
        private readonly GetInactiveUsersQuery query;
        public InactiveModel(Providers providers)
        {
            Input = new List<UserListItem>();
            query = new GetInactiveUsersQuery(providers);
        }
        public IList<UserListItem> Input { get; set; }
        public async void OnGet()
        {
            Input = await query.ExecuteAsync();
        }
    }
}
