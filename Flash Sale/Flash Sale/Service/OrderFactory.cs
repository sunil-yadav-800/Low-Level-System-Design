using Flash_Sale.Entity;
namespace Flash_Sale.Service
{
    public static class OrderFactory
    {
        public static Order CreateOrder(int id, Product product, int quantity)
        {
            if(product == null || quantity<=0)
            {
                return null;
            }
            return new Order(id, product, quantity);
        }
    }
}
