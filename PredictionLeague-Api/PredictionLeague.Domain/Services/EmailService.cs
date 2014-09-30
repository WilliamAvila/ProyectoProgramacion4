using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PredictionLeague.Domain.Services
{
    public class EmailService{
        public IRestResponse SendSimpleMessage(string email) {
            var client = new RestClient
            {
                BaseUrl = "https://api.mailgun.net/v2",
                Authenticator = new HttpBasicAuthenticator("api",
                    "key-2sku5netkmfk9ve1dit2za5g8ogolfz2")
            };
            var request = new RestRequest();
            request.AddParameter("domain",
                                "app47a55a28f93a4907a4e24d09a84a213d.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "PredictionLeague William <postmaster@app47a55a28f93a4907a4e24d09a84a213d.mailgun.org>");
            request.AddParameter("to", email);
            request.AddParameter("subject", "Recover Password");
            var text = "Hi " + email + ", This email is for a Password Reset";
            request.AddParameter("text", text);
            request.Method = Method.POST;
            return client.Execute(request);
        }

    public IRestResponse SendRegisterMessage(string destination, string firstname, string lastname, string displayname)
    {
        var client = new RestClient
        {
            BaseUrl = "https://api.mailgun.net/v2",
            Authenticator = new HttpBasicAuthenticator("api",
                "key-2sku5netkmfk9ve1dit2za5g8ogolfz2")
        };
        var request = new RestRequest();
        request.AddParameter("domain",
                            "app47a55a28f93a4907a4e24d09a84a213d.mailgun.org", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "PredictionLeague William <postmaster@app47a55a28f93a4907a4e24d09a84a213d.mailgun.org>");
        request.AddParameter("to", destination);
        request.AddParameter("subject", "Sign Up Process");
        String message = "Hi " + firstname + " " + lastname + ", Thanks for signup on PredictionLeague." + displayname;
        request.AddParameter("text", message);
        request.Method = Method.POST;
        return client.Execute(request);
    }

    }
}

