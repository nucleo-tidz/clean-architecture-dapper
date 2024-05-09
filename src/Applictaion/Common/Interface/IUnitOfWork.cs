using Domain.Common;

namespace Applictaion.Common.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit(BaseEntity entity);

    }
}
