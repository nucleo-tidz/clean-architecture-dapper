namespace Domain.Common
{
    public abstract class BaseEntity
    {
        private readonly List<IDomainEvent> events = new List<IDomainEvent>();
        public void AddDomainEvent(IDomainEvent domainEvents)
        {
            events.Add(domainEvents);
        }
        public void RemoveDomainEvent(IDomainEvent domainEvents)
        {
            events.Add(domainEvents);
        }
        public void ClearDomainEvents(IDomainEvent domainEvents)
        {
            events.Clear();
        }
    }
}
