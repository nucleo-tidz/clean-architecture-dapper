using Applictaion.Common.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using MediatR;
using Applictaion.Common.Event;
using Domain.Common;

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
        public void Commit(BaseEntity entity)
        {
            try
            {
                _eventPublisher.Publish(entity.events.ToArray());
                _connectionFactory.Transaction.Commit();
              
            }
            catch
            {
                _connectionFactory.Transaction.Rollback();

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
