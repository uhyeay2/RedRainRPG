using RedRainRPG.Domain.Extensions;
using RedRainRPG.Domain.Interfaces;

namespace RedRainRPG.Domain.Models.BaseModels.BaseRequests
{
    public abstract class EmailBasedRequest : IValidatable
    {
        public string Email { get; set; } = string.Empty;

        protected EmailBasedRequest(string email)
        {
            Email = email;
        }

        protected EmailBasedRequest()
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
