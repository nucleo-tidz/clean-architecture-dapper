namespace Applictaion.Common.Interface
{
    public interface IInventoryRepository
    {
         Task<int> Reduce(int[] productId);
    }
}
