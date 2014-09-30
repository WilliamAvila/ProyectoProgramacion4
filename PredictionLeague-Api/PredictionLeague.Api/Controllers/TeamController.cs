using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AttributeRouting.Web.Mvc;
using AutoMapper;
using PredictionLeague.Domain.Entities;
using PredictionLeague.Domain.Services;
using PredictionLeague.Api.Controllers;

using PredictionLeague.Api.Models;


namespace PredictionLeague.Api.Controllers
{
    public class TeamController : BaseApiController
    {

        readonly IWriteOnlyRepository _writeOnlyRepository;
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IMappingEngine _mappingEngine;

        public TeamController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository, IMappingEngine mappingEngine)
        {
            _readOnlyRepository = readOnlyRepository;

            _writeOnlyRepository = writeOnlyRepository;
            _mappingEngine = mappingEngine;
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.AcceptVerbs("GET", "HEAD")]
        [GET("teams")]
        public List<TeamModel> GetAllTeams()
        {
            var userTokenModel = GetUserTokenModel();
            if (userTokenModel == null)
                throw new HttpException((int)HttpStatusCode.Unauthorized, "User is not authorized");

            var teams = _readOnlyRepository.GetAll<Team>().ToList();
            var teamModel = _mappingEngine.Map<List<Team>, List<TeamModel>>(teams);
            return teamModel;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("addTeam")]
        public CreatedTeamModel AddNewTeam([FromBody] TeamModel model)
        {

            var newTeam= _mappingEngine.Map<TeamModel, Team>(model);


            var createdTeam = _writeOnlyRepository.Create(newTeam);
            var createdTeamModel = _mappingEngine.Map<Team, CreatedTeamModel>(createdTeam);
            return createdTeamModel;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("deleteTeam")]
        public long DeleteTeam([FromBody] long Id)
        {

            var teamtoDelete = _readOnlyRepository.GetById<Team>(Id);
            _writeOnlyRepository.Delete<Team>(teamtoDelete.Id);
            return Id;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("editTeam")]
        public void EditTeam([FromBody] TeamModel model)
        {

            var teamtoEdit = _mappingEngine.Map<TeamModel, Team>(model);
            _writeOnlyRepository.Update(teamtoEdit);

        }

     

    }
}