using PredictionLeague.Domain.Entities;

namespace PredictionLeague.Api.Models
{
    public class CreatedGameModel
    {
        public long IdLeague { get; set; }
        public string Local { get; set; }
        public string Visitor { get; set; }
    }


}