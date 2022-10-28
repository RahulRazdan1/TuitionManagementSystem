using Application.Common;
using Application.Identity;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Web.Extensions;

namespace Web.Common
{
    public class UserContext
    {
        const string UserIdKey = "UserId";
        const string UserNameKey = "UserName";
        const string RoleKey = "Role";
        const string NameKey = "Name"; 
        const string IsAuthenticatedUserKey = "IsAuthenticatedUser";
        private readonly ISession session;
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor == null)
            {
                throw new ArgumentNullException(nameof(httpContextAccessor));
            }
            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(HttpContext));
            }
            if (httpContext.Session == null) throw new ArgumentNullException(nameof(ISession));
            session = httpContext.Session;
        }
        public long UserId
        {
            get
            {
                var userIdAsString = session.GetString(UserIdKey);
                if (string.IsNullOrWhiteSpace(userIdAsString))
                {
                    throw new InvalidOperationException("UserId is not assigned");
                }
                if (!long.TryParse(userIdAsString, out long userId))
                {
                    throw new InvalidOperationException($"{userIdAsString} is not a valid UserId");
                }
                return userId;
            }
        }
        public string UserName
        {
            get
            {
                var userName = session.GetString(UserNameKey);
                if (string.IsNullOrWhiteSpace(userName))
                {
                    throw new InvalidOperationException("Username is not assigned");
                }
                return userName;
            }
        }
        public bool IsAuthenticatedUser
        {
            get
            {
                var isAuthenticatedAsString = session.GetString(IsAuthenticatedUserKey);
                if (string.IsNullOrWhiteSpace(isAuthenticatedAsString))
                {
                    return false;
                }
                bool.TryParse(isAuthenticatedAsString, out bool result);
                return result;
            }
            private set
            {
                session.SetString(IsAuthenticatedUserKey, value.ToString());
            }
        }
        public ApplicationRole Role
        {
            get
            {
                return GetObjectFromSession<ApplicationRole>(RoleKey);
            }
        }
        public string? Name
        {
            get
            {
                return session.GetString(NameKey);
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should not be null or empty");
                }
                session.SetString(NameKey, value);
            }
        }
        public void SetSignInDetail(long userId, string userName)
        {
            if (userId <= 0)
            {
                throw new ArgumentException($"{userId} is not a valid user id");
            }
            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }

            SetUserId(userId);
            SetUserName(userName);
            IsAuthenticatedUser = true;
        }
        public void SetRole(ApplicationRole role)
        {
            if (role == null)
            {
                throw new ArgumentException("Role is required", nameof(role));
            }
            SetObjectToSession(RoleKey, role);
        }
        public void SignOut()
        {
            session.Clear();
        }
        private void SetUserId(long userId)
        {
            string existingUserId = session.GetString(UserIdKey);
            if (!string.IsNullOrWhiteSpace(existingUserId))
            {
                throw new InvalidOperationException("UserId is already assigned");
            }
            session.SetString(UserIdKey, userId.ToString());
        }
        private void SetUserName(string userName)
        {
            var existingUserName = session.GetString(UserNameKey);
            if (!string.IsNullOrWhiteSpace(existingUserName))
            {
                throw new InvalidOperationException("UserName is already assigned");
            }
            session.SetString(UserNameKey, userName);
        }
        private void SetObjectToSession(string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        private Type GetObjectFromSession<Type>(string key) where Type: class
        {
            string? sessionValue = session.GetString(key);
            if (sessionValue == null) return null;
            return JsonSerializer.Deserialize<Type>(sessionValue);
        }

    }
}
