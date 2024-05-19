using Applictaion.Common.Interface;
using Dapper;
using Domain.Entities;
using Infrastructure.Common;

namespace Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        public InventoryRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> Reduce(int[] productId)
        {
            string query = @"Update Inventory set Quantity= Quantity-1 where ProductId in (@ProductId)";

            return await _connectionFactory.Connection.ExecuteAsync(query, new { productId = productId }, transaction: _connectionFactory.Transaction);
        }
    }
}
