using RedRainRPG.Domain.Models.BaseModels;

namespace RedRainRPG.Domain.Models.PlayerModels.PlayerResponses
{
    public class IsEmailRegisteredResponse : BaseResponse
    {
        public IsEmailRegisteredResponse(bool isRegistered)
        {
            IsRegistered = isRegistered;
        }

        public bool IsRegistered { get; set; }
    }
}
