using PredictionLeague.Domain.Entities;

namespace PredictionLeague.Api.Models
{
    public class AccountGameModel
    {
        public long Id { get; set; }
        public string Local { get; set; }
        public string Visitor { get; set; }
        public string AccountId { get; set; }
        public string Score { get; set; }
    }


}