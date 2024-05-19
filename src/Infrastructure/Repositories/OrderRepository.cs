using Applictaion.Common.Interface;
using Dapper;
using Domain.Entities;
using Infrastructure.Common;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly  ConnectionFactory _connectionFactory;
        public OrderRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory; 
        }
        public async Task<int> Save(Order order)
        {
            string query = @"INSERT INTO [dbo].[Order]
                             ([Name]
                             ,[Description]
                             ,[OrderedBy])
                       VALUES
                             (@name
                             ,@description
                             ,@orderedBy)";

         
            return await _connectionFactory.Connection.ExecuteAsync(query, new { name = order.Name, description = order.Description, orderedBy = order.OrderedBy },transaction:_connectionFactory.Transaction);

        }
    }
}
