using DomainDrivenDatabaseDeployer;
using NHibernate;
using PredictionLeague.Domain.Entities;

namespace PredictionLeague.DataBaseDeployer
{
    public class LeagueSeeder : IDataSeeder
    {
        readonly ISession _session;

        public LeagueSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {

            Leagues[] leagueA =
            {
                new Leagues {Name = "MLS"},
                new Leagues {Name = "MLB"},
                new Leagues {Name = "NFL"},
                new Leagues {Name = "NHL"},
                new Leagues {Name = "NBA"},
            };

            foreach (var league in leagueA)
            {
                _session.Save(league);
            }
        }
    }
}