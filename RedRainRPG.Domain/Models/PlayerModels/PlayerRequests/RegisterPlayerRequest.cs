using RedRainRPG.Domain.Interfaces;

namespace RedRainRPG.Domain.Models.PlayerModels.PlayerRequests
{
    public class RegisterPlayerRequest : IValidatable
    {
        public RegisterPlayerRequest()
        {
        }

        public RegisterPlayerRequest(string emailAddress, string accountName)
        {
            EmailAddress = emailAddress;
            AccountName = accountName;
        }

        public string? EmailAddress { get; set; }
        public string? AccountName { get; set; }

        public bool IsValid(out string failedValidationMessage)
        {
            var isValid = true;
            failedValidationMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(EmailAddress))
            {
                isValid = false;
                failedValidationMessage = "EmailAddress Cannot Be Null or Empty/Whitespace! ";
            }

            if (string.IsNullOrWhiteSpace(AccountName))
            {
                isValid = false;
                failedValidationMessage += "AccountName Cannot Be Null or Empty/Whitespace! ";
            }

            return isValid;
        }
    }
}
