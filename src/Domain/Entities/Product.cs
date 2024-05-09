using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        private Product() { }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Price Price { get; private set; }

        public static Product Create(int id, string name, string description, Price price)
        {
            return new Product { Id = id, Name = name, Description = description, Price = price };
        }
    }
}
