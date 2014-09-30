using DomainDrivenDatabaseDeployer;
using NHibernate;
using PredictionLeague.Domain.Entities;

namespace PredictionLeague.DataBaseDeployer
{
    public class GameSeeder : IDataSeeder
    {
        readonly ISession _session;

        public GameSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            Game[] games =
            {
                new Game{ IdLeague=1,Local = "Chicago Fire", Visitor =  "Columbus Crew" },
                new Game{ IdLeague=1,Local =  "Houston" , Visitor = "D.C United" }
            };


            foreach (var gm in games)
            {
                _session.Save(gm);
            }
        }
    }
}