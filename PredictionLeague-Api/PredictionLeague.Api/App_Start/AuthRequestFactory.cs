using System.Web.Script.Serialization;
using PredictionLeague.Api.Models;

namespace PredictionLeague.Api
{
    public class AuthRequestFactory
    {
        public static string BuildEncryptedRequest(string email)
        {
            var request = new UserTokenModel
            {
                email = email
            };

            string jsonRequest = new JavaScriptSerializer().Serialize(request);
            string encryptedRequest = Encripter.Encrypt(jsonRequest);
            return encryptedRequest;
        }

        public static UserTokenModel BuildDecryptedRequest(string encryptedToken)
        {
            var jsonString = Encripter.Decrypt(encryptedToken);
            var decryptedAuthRequest = new JavaScriptSerializer().Deserialize<UserTokenModel>(jsonString);
            return decryptedAuthRequest;
        }
    }
}