namespace Flash_Sale.Entity
{
    public class Product
    {
        public string ProductName { get; set; }
        public int Quentity { get; set; }
        public Product(string productName, int quentity)
        {
            ProductName = productName;
            Quentity = quentity;
        }
    }
}
