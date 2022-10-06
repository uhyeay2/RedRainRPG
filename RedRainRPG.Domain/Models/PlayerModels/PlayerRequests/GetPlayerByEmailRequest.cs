using RedRainRPG.Domain.Models.BaseModels.BaseRequests;

namespace RedRainRPG.Domain.Models.PlayerModels.PlayerRequests
{
    public class GetPlayerByEmailRequest : EmailBasedRequest
    {
        public GetPlayerByEmailRequest()
        {
        }

        public GetPlayerByEmailRequest(string email) : base(email)
        {
        }
    }
}
