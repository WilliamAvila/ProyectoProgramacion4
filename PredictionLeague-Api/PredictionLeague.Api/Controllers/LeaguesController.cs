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
    public class LeaguesController : BaseApiController
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IMappingEngine _mappingEngine;
        readonly IWriteOnlyRepository _writeOnlyRepository;

        public LeaguesController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository, IMappingEngine mappingEngine)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
            _mappingEngine = mappingEngine;
        }
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.AcceptVerbs("GET", "HEAD")]
        [GET("leagues/available")]
        public List<LeaguesModel> GetAvailableLeagues()
        {
            var userTokenModel = GetUserTokenModel();
            if (userTokenModel == null)
                throw new HttpException((int)HttpStatusCode.Unauthorized, "User is not authorized");

            var leagues = _readOnlyRepository.GetAll<Leagues>().ToList();
            var leaguesModel = _mappingEngine.Map<List<Leagues>, List<LeaguesModel>>(leagues);
            return leaguesModel;
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.AcceptVerbs("GET", "HEAD")]
        [GET("leagues/suscribed")]
        public List<LeaguesModel> GetSuscribedLeagues()
        {
            var userTokenModel = GetUserTokenModel();
            if (userTokenModel == null)
                throw new HttpException((int)HttpStatusCode.Unauthorized, "User is not authorized");

            var account = _readOnlyRepository.Query<AccountLeagues>(x => x.User.Email == userTokenModel.email).Select(y => y.League);
            var leaguesModel = _mappingEngine.Map<List<Leagues>, List<LeaguesModel>>(account.ToList());
            return leaguesModel;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("addLeague")]
        public CreatedLeagueModel AddNewLeague([FromBody] LeaguesModel model)
        {

            var newLeague = _mappingEngine.Map<LeaguesModel, Leagues>(model);


            var createdLeague = _writeOnlyRepository.Create(newLeague);
            var createdLeagueModel = _mappingEngine.Map<Leagues, CreatedLeagueModel>(createdLeague);
            return createdLeagueModel;
        }


        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("deleteLeague")]
        public long Deleteleague([FromBody] long Id)
        {

            var leaguetoDelete = _readOnlyRepository.GetById<Leagues>(Id);
            _writeOnlyRepository.Delete<Leagues>(leaguetoDelete.Id);
            return Id;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("editLeague")]
        public void EditLeague([FromBody] LeaguesModel model)
        {

            var leaguetoEdit = _mappingEngine.Map<LeaguesModel, Leagues>(model);
            _writeOnlyRepository.Update(leaguetoEdit);
           
        }

    }
}