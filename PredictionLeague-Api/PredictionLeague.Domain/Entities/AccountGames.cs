namespace PredictionLeague.Domain.Entities
{
    public class AccountGames : IEntity
    {
        public virtual long Id { get; set; }
        public virtual long AccountId { get; set; }
        public virtual string Local { get; set; }
        public virtual string Visitor { get; set; }
        public virtual string Score { get; set; }
    }
}