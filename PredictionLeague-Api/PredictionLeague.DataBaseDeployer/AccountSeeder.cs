using DomainDrivenDatabaseDeployer;
using NHibernate;
using PredictionLeague.Domain.Entities;
using PredictionLeague.Domain.Services;

namespace PredictionLeague.DataBaseDeployer
{
    public class AccountSeeder : IDataSeeder
    {
        readonly ISession _session;
        private SimpleAES smpAes = new SimpleAES();

        public AccountSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {

            var account = new Account
            {
                Email = "test@test.com",
                Name = "Test Name",
                //Password = smpAes.Encrypt("password")
                
                Status="admin",
                Password="password"
            };
            _session.Save(account);
        }
    }
}