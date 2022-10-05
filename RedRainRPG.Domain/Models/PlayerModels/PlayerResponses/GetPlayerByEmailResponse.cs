using RedRainRPG.Domain.Models.BaseModels;

namespace RedRainRPG.Domain.Models.PlayerModels.PlayerResponses
{
    public class GetPlayerByEmailResponse : BaseResponse
    {
        public GetPlayerByEmailResponse(Player player)
        {
            Player = player;
        }

        public Player Player { get; set; }
    }
}
