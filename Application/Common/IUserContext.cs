namespace Application.Common
{
    public interface IUserContext
    {
        long UserId { get; }
        string UserName { get;  }
        bool IsAuthenticatedUser { get; }
        string? Name { get; set; }
        void SetSignInDetail(long userId , string userName);
        void SetRole(string role);
        void SignOut();

    }
}
