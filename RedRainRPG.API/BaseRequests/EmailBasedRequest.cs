using RedRainRPG.Domain.Extensions;
using RedRainRPG.Domain.Interfaces;

namespace RedRainRPG.API.BaseRequests
{
    public class EmailBasedRequest : IValidatable
    {
        public string Email { get; set; } = string.Empty;

        public EmailBasedRequest(string email)
        {
            Email = email;
        }

        public EmailBasedRequest()
        {
        }

        public virtual bool IsValid(out string failedValidationMessage)
        {
            var isValid = true;
            failedValidationMessage = string.Empty;

            if (!Email.IsValidEmailFormat())
            {
                isValid = false;
                failedValidationMessage = $"Must provide a valid email address! Email received: {Email}";
            }

            return isValid;
        }
    }
}
