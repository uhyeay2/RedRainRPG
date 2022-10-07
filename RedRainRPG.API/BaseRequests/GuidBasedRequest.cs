using RedRainRPG.Domain.Interfaces;

namespace RedRainRPG.API.BaseRequests
{
    public class GuidBasedRequest : IValidatable
    {
        public Guid Guid { get; set; }

        public GuidBasedRequest(Guid guid) => Guid = guid;

        public GuidBasedRequest() { }

        public bool IsValid(out string failedValidationMessage)
        {
            var isValid = true;
            failedValidationMessage = String.Empty;

            if (Guid == Guid.Empty)
            {
                isValid = false;
                failedValidationMessage = $"Invalid Request! Must provide Guid! Guid received: {Guid}";
            }

            return isValid;
        }
    }
}
