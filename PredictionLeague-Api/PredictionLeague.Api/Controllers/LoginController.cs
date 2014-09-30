using System.Net;
using System.Web;
using System.Web.Http;
using AcklenAvenue.Data.NHibernate;
using AttributeRouting.Web.Mvc;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using PredictionLeague.Domain.Entities;
using PredictionLeague.Domain.Services;
using PredictionLeague.Api.Models;

namespace PredictionLeague.Api.Controllers
{
    public class LoginController:ApiController
    {
        readonly IReadOnlyRepository _readOnlyRepository;


        public LoginController(IReadOnlyRepository readOnlyRepository )
        {
            
            _readOnlyRepository = readOnlyRepository;
        }

        [HttpPost]
        [AcceptVerbs("POST","HEAD")]
        [POST("login")]
        public AuthModel Login([FromBody] AccountLoginModel model)
        {
            var user = _readOnlyRepository.FirstOrDefault<Account>(x => x.Email == model.Email);
            if (user == null) throw new HttpException((int) HttpStatusCode.NotFound, "User doesn't exist.");
            if (!user.CheckPassword(model.Password))
                throw new HttpException((int) HttpStatusCode.Unauthorized, "Password doesn't match.");
            var authModel = new AuthModel { access_token = "SuperHash" };
            return authModel;
        }


    }
}