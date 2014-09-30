using AutoMapper;
using PredictionLeague.Api.Models;
using PredictionLeague.Domain.Entities;

namespace PredictionLeague.Api
{
    public class ConfigureAutomapper : IBootstrapperTask
    {
        #region IBootstrapperTask Members

        public void Run()
        {
            //automappings go here
            //Ex: Mapper.CreateMap<SomeType, SomeOtherType>().ReverseMap();
            Mapper.CreateMap<AccountRegisterModel, Account>().ReverseMap();
            Mapper.CreateMap<CreatedAccountModel, Account>().ReverseMap();
            Mapper.CreateMap<Leagues, LeaguesModel>().ReverseMap();
            Mapper.CreateMap<Team, TeamModel>().ReverseMap();
            Mapper.CreateMap<CreatedTeamModel, Team>().ReverseMap();
            Mapper.CreateMap<Leagues, CreatedLeagueModel>().ReverseMap();
            Mapper.CreateMap<Game, GameModel>().ReverseMap();
            Mapper.CreateMap<Game, CreatedGameModel>().ReverseMap();
            Mapper.CreateMap<AccountGames, AccountGameModel>().ReverseMap();
        }

        #endregion
    }
}