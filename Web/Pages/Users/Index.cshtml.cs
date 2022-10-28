using Application.Common;
using Application.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly GetAllUsersQuery getAllUsers;
        public IndexModel(Providers providers)
        {
            getAllUsers = new GetAllUsersQuery(providers);
        }

        public IList<UserListItem> Input { get; private set; }
        public async Task OnGetAsync()
        {
            Input = await getAllUsers.ExecuteAsync();
        }
    }
}
