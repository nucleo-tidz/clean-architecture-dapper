using Domain.Common;

namespace Applictaion.Common.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit<TEntity>(TEntity entity) where TEntity : BaseEntity;

    }
}
