using Flash_Sale.Entity;


namespace Flash_Sale.Service
{
    public static class ProductFactory
    {
        public static Product CreateProduct(string productName, int quantity)
        {
            if (string.IsNullOrEmpty(productName) || quantity < 0)
            {
                return null;
            }
            return new Product(productName, quantity);
        }
    }
}
