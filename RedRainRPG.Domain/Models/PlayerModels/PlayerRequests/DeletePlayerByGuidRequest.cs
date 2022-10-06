using RedRainRPG.Domain.Models.BaseModels.BaseRequests;

namespace RedRainRPG.Domain.Models.PlayerModels.PlayerRequests
{
    public class DeletePlayerByGuidRequest : GuidBasedRequest
    {
        public DeletePlayerByGuidRequest()
        {
        }

        public DeletePlayerByGuidRequest(Guid? guid) : base(guid)
        {
        }
    }
}
