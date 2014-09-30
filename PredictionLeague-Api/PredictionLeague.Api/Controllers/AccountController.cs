using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AttributeRouting.Web.Mvc;
using AutoMapper;
using PredictionLeague.Api.Models;
using PredictionLeague.Domain.Entities;
using PredictionLeague.Domain.Services;

namespace PredictionLeague.Api.Controllers
{
    public class AccountController : BaseApiController
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IWriteOnlyRepository _writeOnlyRepository;
        readonly IMappingEngine _mappingEngine;

        private EmailService Ems = new EmailService();
        private SimpleAES smpAes = new SimpleAES();

        public AccountController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository, IMappingEngine mappingEngine)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
            _mappingEngine = mappingEngine;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("register")]
        public CreatedAccountModel Register([FromBody] AccountRegisterModel model)
        {
            
            Ems.SendRegisterMessage(model.Email, model.Name, model.LastName, model.DisplayName);
            var newUser = _mappingEngine.Map<AccountRegisterModel, Account>(model);

            newUser.Status = "user";
            var createdUser = _writeOnlyRepository.Create(newUser);
            var craetedUserModel = _mappingEngine.Map<Account, CreatedAccountModel>(createdUser);
            return craetedUserModel;
        }


        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("login")]
        public AuthModel Login([FromBody] AccountLoginModel model)
        {
            var user = _readOnlyRepository.FirstOrDefault<Account>(x => x.Email == model.Email);
            if (user == null) throw new HttpException((int)HttpStatusCode.NotFound, "User doesn't exist.");
            if (!user.CheckPassword(model.Password))
                throw new HttpException((int)HttpStatusCode.Unauthorized, "Password doesn't match.");

            var authModel = new AuthModel
            {
                email = user.Email,
                access_token = AuthRequestFactory.BuildEncryptedRequest(user.Email),
                role = new RoleModel
                {
                    bitMask = 2,
                    title = user.Status
                }
            };

            return authModel;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("forgotpassword")]
        public AuthModel ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            Ems.SendSimpleMessage(model.Email);
            var user = _readOnlyRepository.FirstOrDefault<Account>(x => x.Email == model.Email);
            if (user == null) throw new HttpException((int)HttpStatusCode.NotFound, "User doesn't exist.");
            var authModel = new AuthModel { access_token = "SuperHash" };
            return authModel;
        }

       
        /*[HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("prediction")]
        public CreatedPredictionModel Prediction([FromBody] GameModel model)
        {

            var newUser = _mappingEngine.Map<PredictionModel, Prediction>(model);


            var createdUser = _writeOnlyRepository.Create(newUser);
            var craetedUserModel = _mappingEngine.Map<Account, CreatedPredictionModel>(createdUser);
            return craetedUserModel;
        }*/


    }
}