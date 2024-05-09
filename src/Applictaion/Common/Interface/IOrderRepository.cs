using domain = Domain;

namespace Applictaion.Common.Interface
{
    public interface IOrderRepository
    {
        Task<int> Save(domain.Entities.Order order);
    }
}
