namespace PredictionLeague.Domain.Entities
{
    public class Team: IEntity
    {

        public virtual string Name { get; set; }
        public virtual long Id { get; set; }
        public virtual long IdLeague { get; set; }
        
    }
}