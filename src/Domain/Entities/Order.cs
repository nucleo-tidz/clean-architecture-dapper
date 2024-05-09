using Domain.Common;
using System.Runtime.InteropServices;

namespace Domain.Entities
{
    public class Order: BaseEntity
    {
        private Order() { }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string OrderedBy { get; private set; }
        public List<LineItem> LineItems { get; private set; } = new List<LineItem>();

        public static Order Create(int id, string name, string description, string orderedBy)
        {
            return new Order { Id = id, Name = name, Description = description, OrderedBy = orderedBy };
        }

        public void AddLineItem(Product product)
        {
            LineItems.Add(LineItem.Create(Id, product));
        }
    }
}
