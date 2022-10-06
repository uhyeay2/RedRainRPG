using RedRainRPG.Domain.Interfaces;
using RedRainRPG.Domain.Models.BaseModels.BaseRequests;

namespace RedRainRPG.Domain.Models.PlayerModels.PlayerRequests
{
    public class RegisterPlayerRequest : EmailBasedRequest, IValidatable
    {
        public RegisterPlayerRequest()
        {
        }

        public RegisterPlayerRequest(string emailAddress, string accountName) : base(emailAddress)
        {
            AccountName = accountName;
        }

        public string AccountName { get; set; } = string.Empty;

        public override bool IsValid(out string failedValidationMessage)
        {
            var isValid = base.IsValid(out failedValidationMessage);

            if (string.IsNullOrWhiteSpace(AccountName))
            {
                isValid = false;
                failedValidationMessage += "AccountName Cannot Be Null or Empty/Whitespace! ";
            }

            return isValid;
        }
    }
}
