using DomainDrivenDatabaseDeployer;
using NHibernate;
using PredictionLeague.Domain.Entities;

namespace PredictionLeague.DataBaseDeployer
{
    public class TeamSeeder : IDataSeeder
    {
        readonly ISession _session;

        public TeamSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {   
              Team []teamsA={new Team{ Name= "Chicago Fire", IdLeague= 1 }, new Team{ Name= "Columbus Crew", IdLeague= 1 }, new Team{ Name= "D.C United", IdLeague= 1 }, new Team{ Name= "New York Red Bulls", IdLeague= 1 },
                new Team{ Name= "New England Revolution", IdLeague= 1 }, new Team{ Name= "Houston Dynamo", IdLeague= 1 }, new Team{ Name= "Montreal Impact", IdLeague= 1 }, new Team{ Name= "Toronto FC", IdLeague= 1 },
                new Team{ Name= "Texas Rangers", IdLeague= 2 }, new Team{ Name= "Toronto Blue Jays", IdLeague= 2 }, new Team{ Name= "Tampa Bay Rays", IdLeague= 2 }, new Team{ Name= "Seattle Mariners", IdLeague= 2 },
                 new Team { Name= "Oakland Athletics", IdLeague= 2 }, new Team{ Name= "New York Yankees", IdLeague= 2 }, new Team{ Name= "Los Angeles Angels", IdLeague= 2 }, new Team{ Name= "Boston Red Sox", IdLeague= 2 },
                new Team{ Name= "Tampa Bay Buccaneers", IdLeague= 3 }, new Team{ Name= "Baltimore Ravens", IdLeague= 3 }, new Team{ Name= "Pittsburgh Steelers", IdLeague= 3 }, new Team{ Name= "Atlanta Falcons", IdLeague= 3 },
                new Team{ Name= "Green Bay Packers", IdLeague= 3 }, new Team{ Name= "Detroit Lions", IdLeague= 3 }, new Team{ Name= "New York Giants", IdLeague= 3 }, new Team{ Name= "Washington Redskins", IdLeague= 3 },
                new Team{ Name= "ANAHEIM DUCKS", IdLeague= 4 }, new Team{ Name= "ARIZONA COYOTES", IdLeague= 4 }, new Team{ Name= "COLORADO AVALANCHE", IdLeague= 4 }, new Team{ Name= "MINNESOTAWILD", IdLeague= 4 },
                new Team{ Name= "FLORIDA PANTHERS", IdLeague= 4 }, new Team{ Name= "DETROIT RED WINGS", IdLeague= 4 }, new Team{ Name= "BUFFALO SABRES", IdLeague= 4 }, new Team{ Name= "TAMPA BAYLIGHTNING", IdLeague= 4 },
                new Team{ Name= "Boston Celtics", IdLeague= 5 }, new Team{ Name= "Dallas Mavericks", IdLeague= 5 }, new Team{ Name= "Orlando Magic", IdLeague= 5 }, new Team{ Name= "Atlanta Hawks", IdLeague= 5 },
                new Team{ Name= "Chicago Bulls", IdLeague= 5 }, new Team{ Name= "Los Angeles Lakers", IdLeague= 5 }, new Team{ Name= "Miami Heat", IdLeague= 5 }, new Team{ Name= "Cleveland Cavaliers", IdLeague= 5 }
            };

              foreach (var team in teamsA)
            {
                _session.Save(team);
            }
        }
    }
}