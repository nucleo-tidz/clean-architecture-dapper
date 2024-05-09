using Applictaion.Common.Interface;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<int> Save(Order order)
        {
            return Task.FromResult(1);
        }
    }
}
