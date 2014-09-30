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
    public class GameController : BaseApiController
    {
        readonly IReadOnlyRepository _readOnlyRepository;
        readonly IMappingEngine _mappingEngine;
        readonly IWriteOnlyRepository _writeOnlyRepository;

        public GameController(IReadOnlyRepository readOnlyRepository, IWriteOnlyRepository writeOnlyRepository, IMappingEngine mappingEngine)
        {
            _readOnlyRepository = readOnlyRepository;
            _writeOnlyRepository = writeOnlyRepository;
            _mappingEngine = mappingEngine;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("addGame")]
        public CreatedGameModel AddGame([FromBody]GameModel model)
        {

            var newGame = _mappingEngine.Map<GameModel, Game>(model);


            var createdGame = _writeOnlyRepository.Create(newGame);
            var craetedGameModel = _mappingEngine.Map<Game, CreatedGameModel>(createdGame);
            return craetedGameModel;
        }


        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("makePrediction")]
        public void makePrediction([FromBody]AccountGameModel model)
        {

            var newPrediction = _mappingEngine.Map<AccountGameModel, AccountGames>(model);


            var createdPrediction = _writeOnlyRepository.Create(newPrediction);
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.AcceptVerbs("GET", "HEAD")]
        [GET("getGames")]
        public List<GameModel> GetGames()
        {
            var userTokenModel = GetUserTokenModel();
            if (userTokenModel == null)
                throw new HttpException((int)HttpStatusCode.Unauthorized, "User is not authorized");

            var games = _readOnlyRepository.GetAll<Game>().ToList();
            var gamesModel = _mappingEngine.Map<List<Game>, List<GameModel>>(games);
            return gamesModel;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("deleteGame")]
        public long DeleteGame([FromBody] long Id)
        {

            var gametoDelete = _readOnlyRepository.GetById<Game>(Id);
            _writeOnlyRepository.Delete<Game>(gametoDelete.Id);
            return Id;
        }

        [HttpPost]
        [AcceptVerbs("POST", "HEAD")]
        [POST("editGame")]
        public void EditGame([FromBody] GameModel model)
        {

            var gametoEdit = _mappingEngine.Map<GameModel, Game>(model);
            _writeOnlyRepository.Update(gametoEdit);

        }

       
    }
}