namespace PredictionLeague.Api.Models
{
    public class AuthModel
    {
        public string email { get; set; }
        public string access_token { get; set; }
        public RoleModel role { get; set; }

    }
}