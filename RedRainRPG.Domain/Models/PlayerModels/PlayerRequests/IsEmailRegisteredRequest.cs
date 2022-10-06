using RedRainRPG.Domain.Models.BaseModels.BaseRequests;

namespace RedRainRPG.Domain.Models.PlayerModels.PlayerRequests
{
    public class IsEmailRegisteredRequest : EmailBasedRequest
    {
        public IsEmailRegisteredRequest()
        {
        }

        public IsEmailRegisteredRequest(string email) : base(email)
        {
        }
    }
}
