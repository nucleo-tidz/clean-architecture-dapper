using Domain.Common;

namespace Domain.Entities
{
    public class Inventory: BaseEntity
    {
        private  Inventory() { }

        public int Id { get; private set; }

        public Product Product { get; private set; }

        public long Quantity { get; set; }

        public static Inventory Create(int Id, Product Product, long quantity)
        {
            return new Inventory { Id = Id, Product = Product, Quantity = quantity };
        }
    }
}
