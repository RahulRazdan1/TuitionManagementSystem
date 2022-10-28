using Microsoft.Extensions.Configuration;

namespace Application.Emails
{
    public interface IEmailer
    {
        bool TrySendEmail(string to, string subject, string message);
    }
}
