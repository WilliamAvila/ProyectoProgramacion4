namespace PredictionLeague.Domain.Entities
{
    public class Leagues:IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
    }
}