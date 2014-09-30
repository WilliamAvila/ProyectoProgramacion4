namespace PredictionLeague.Domain.Entities
{
    public class League:IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
    }
}