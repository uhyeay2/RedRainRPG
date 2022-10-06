using RedRainRPG.Domain.Interfaces;
using RedRainRPG.Domain.Extensions;

namespace RedRainRPG.Domain.Models.BaseModels.BaseRequests
{
    public abstract class GuidBasedRequest : IValidatable
    {
        public Guid? Guid { get; set; }

        public GuidBasedRequest(Guid? guid) => Guid = guid;

        public GuidBasedRequest() { }

        public bool IsValid(out string failedValidationMessage)
        {
            var isValid = true;
            failedValidationMessage = String.Empty;

            if (Guid.IsNullOrEmpty())
            {
                isValid = false;
                failedValidationMessage = $"Invalid Request! Must provide Guid! Guid received: {Guid}";
            }

            return isValid;
        }
    }
}
