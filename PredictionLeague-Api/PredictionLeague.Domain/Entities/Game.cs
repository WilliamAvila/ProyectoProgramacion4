namespace PredictionLeague.Domain.Entities
{
    public class Game:IEntity
    {
        public virtual long Id { get; set; }
        public virtual long IdLeague { get; set; }
        public virtual string Local { get; set; }
        public virtual string Visitor { get; set; }
        public virtual Team Winner { get; set; }
        public virtual Team Looser { get; set; }
        public virtual string Score { get; set; }
    }
}