using System;
using System.Net;
using System.Web;
using System.Web.Http;
using AcklenAvenue.Data.NHibernate;
using AttributeRouting.Web.Mvc;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using PredictionLeague.Data;
using PredictionLeague.Domain.Entities;
using PredictionLeague.Domain.Services;
using PredictionLeague.Api.Models;
using RestSharp;

namespace PredictionLeague.Api.Controllers
{
    public class RegisterController : ApiController
    {
        readonly IReadOnlyRepository _readOnlyRepository;


        public RegisterController(IReadOnlyRepository readOnlyRepository)
        {

            _readOnlyRepository = readOnlyRepository;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("register")]
        public AuthModel RegisterModel([FromBody] RegisterModel model)
        {
            var resp = SendSimpleMessage(model.Email, model.FirstName, model.LastName, model.DisplayName);
            var user = _readOnlyRepository.FirstOrDefault<Account>(x => x.Email == model.Email);
            var authModel = new AuthModel { access_token = "SuperHash" };
            return authModel;
        }

        public static IRestResponse SendSimpleMessage(string destination, string firstname, string lastname, string displayname)
        {
            var client = new RestClient
            {
                BaseUrl = "https://api.mailgun.net/v2",
                Authenticator = new HttpBasicAuthenticator("api",
                    "key-9y9ypyn3hneqzpz6eojvfj3zzag92332")
            };
            var request = new RestRequest();
            request.AddParameter("domain",
                                "appcf01bdaa3c9642d09d34fcceafc37ac6.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "PredictionLeague | William <postmaster@appcf01bdaa3c9642d09d34fcceafc37ac6.mailgun.org>");
            String email = "<" + destination + ">";
            request.AddParameter("to", email);
            request.AddParameter("subject", "Register Process");
            String text = "Hi " + firstname + " " + lastname + ", congratulations on completing the Register process for Prediliga.  Your registered username is " + displayname;
            request.AddParameter("text", text);
            request.Method = Method.POST;
            return client.Execute(request);
        }

    }
}