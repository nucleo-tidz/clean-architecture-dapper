using Applictaion.Common.Event;
using Applictaion.Common.Interface;
using Domain.Common;
using static Dapper.SqlMapper;

namespace Infrastructure.Common
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IEventPublisher _eventPublisher;
        public UnitOfWork(ConnectionFactory connectionFactory, IEventPublisher eventPublisher)
        {
            _connectionFactory = connectionFactory;
            _eventPublisher = eventPublisher;
        }

        public void BeginTransaction()
        {
            _connectionFactory.Transaction = _connectionFactory.Connection.BeginTransaction();
        }
        public void Commit<TEntity>(TEntity entity)
            where TEntity : BaseEntity
        {
            try
            {
                _eventPublisher.Publish(entity.events.ToArray());
                _connectionFactory.Transaction.Commit();
            }
            catch
            {
                _connectionFactory.Transaction.Rollback();
                throw;
            }
            finally
            {
                _connectionFactory.Transaction.Dispose();
            }
        }
        public void Dispose()
        {
            _connectionFactory.Transaction.Dispose();
        }
    }
}
