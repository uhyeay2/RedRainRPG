using RedRain.DataAccess.Attributes.SQLGeneration.InsertAttributes;
using RedRain.DataAccess.Interfaces;
using RedRainRPG.Domain.Models.PlayerModels.PlayerRequests;

namespace RedRain.DataAccess.RequestObjects.PlayerRequests
{
    [InsertQuery("Player", 
        ifNotExists: "SELECT * FROM Player WITH(NOLOCK) WHERE ( Player.EmailAddress = @EmailAddress ) OR ( Player.AccountName = @AccountName )")]
    internal class RegisterPlayer : IRequestObject
    {
        #region Constructors 

        public RegisterPlayer(string? emailAddress, string? accountName)
        {
            EmailAddress = emailAddress;
            AccountName = accountName;
        }

        public RegisterPlayer(RegisterPlayerRequest request) : this(request?.Email, request?.AccountName) { }

        #endregion

        #region Properties To Insert 

        [Insertable("Player")]
        public string? EmailAddress { get; set; }
        
        [Insertable("Player")]
        public string? AccountName { get; set; }

        #endregion

        #region IRequestObject Properties

        public object? GenerateParameters() => new {EmailAddress, AccountName};

        public string GenerateSql() => _sql;

        private static readonly string _sql = SqlGenerator.Insert(typeof(RegisterPlayer));

        #endregion
    }
}
