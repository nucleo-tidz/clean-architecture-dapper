using Domain.Common;

namespace Domain.Events
{
    public class OrderCreatedEvent : IDomainEvent
    {
        public int OrderId { get; set; }
        public int[] ProductId { get; set; }
    }
}
