using Domain.Common;

namespace Domain.Entities
{
    public class LineItem: BaseEntity
    {
        private LineItem() { }  
        public int Id { get; private set; }
        public Product Product { get; private set; }

        public static LineItem Create(int Id, Product Product)
        {
            return new LineItem
            {
                Id = Id,
                Product = Product
            };
        }
    }
}
