using Applictaion.Common.Interface;
using Domain.Entities;
using Domain.Events;
using Domain.Results;
using Domain.ValueObjects;
using MediatR;
using System.Linq.Expressions;
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
        private readonly IUnitOfWork _unitOfWork;
        public CreateOrderHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var result = domain.Entities.Order.Create(1, request.Name, request.Description, request.CreatedBy);
            if (result.IsSuccess)
            {

                var order = result.Value;
                request.ProductIds.ToList().ForEach(_ =>
                {
                    order.AddLineItem(Product.Create(_, "TV", "NA", Price.Create(1000 * _, "INR")));
                });
                order.AddDomainEvent(new OrderCreatedEvent
                {
                    OrderId = 1,
                    ProductId = order.LineItems.Select(_ => _.Product).Select(_ => _.Id).ToArray()
                });
                _unitOfWork.BeginTransaction();
                int rows = await _orderRepository.Save(order);
                _unitOfWork.Commit(order);
                order.ClearDomainEvents();
                return rows;
            }
            throw new Exception("Domain exception");
        }
    }

}
