using PredictionLeague.Domain.Entities;

namespace PredictionLeague.Api.Models
{
    public class GameModel
    {
        public long Id { get; set; }
        public long IdLeague { get; set; }
        public string Local { get; set; }
        public string Visitor { get; set; }

        public string Score { get; set; }
    }


}