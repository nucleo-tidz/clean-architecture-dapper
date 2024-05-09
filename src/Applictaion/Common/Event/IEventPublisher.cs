using Domain.Common;

namespace Applictaion.Common.Event
{
    public interface IEventPublisher
    {
        void  Publish(IDomainEvent[] events);
    }
}
