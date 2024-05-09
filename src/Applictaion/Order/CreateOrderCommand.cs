using Applictaion.Common.Interface;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;
using domain = Domain;
namespace Applictaion.Order
{
    public record CreateOrderCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public IEnumerable<int> ProductIds { get; set; }

    }
    internal class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = domain.Entities.Order.Create(1, request.Name, request.Description, request.CreatedBy);
            request.ProductIds.ToList().ForEach(_ =>
            {
                order.LineItems.Add(LineItem.Create(1, Product.Create(_, "TV", "NA", Price.Create(1000 * _, "INR"))));
            });
            return await _orderRepository.Save(order);
        }
    }

}
