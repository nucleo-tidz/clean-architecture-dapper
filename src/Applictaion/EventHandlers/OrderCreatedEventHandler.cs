using Applictaion.Common.Interface;
using Domain.Events;
using MediatR;

namespace Applictaion.EventHandlers
{
    public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
    {
       private readonly IInventoryRepository _inventoryRepository;
        public OrderCreatedEventHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;       
        }
        public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            await _inventoryRepository.Reduce(notification.ProductId);
        }
    }
}
