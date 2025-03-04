using Flash_Sale.Entity;
using System.Collections.Concurrent;

namespace Flash_Sale.Service
{
    //singleton class
    public class Inventory
    {
        private ConcurrentDictionary<string, Product> inventory;
        private static readonly Object _lock = new Object();
        private static Inventory _instance;
        private Inventory()
        {
            inventory = new ConcurrentDictionary<string, Product>();
        }
        public static Inventory GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Inventory();
                    }
                }
            }
            return _instance;
        }   
        public void AddProduct(string productName, int quantity)
        {
            try
            {   
                if (inventory.ContainsKey(productName))
                {
                    inventory.TryGetValue(productName, out Product product);
                    if (product != null)
                    {
                        product.Quentity += quantity;
                    }
                }
                else
                {
                    //use ProductFactory to create product
                    Product newProduct = ProductFactory.CreateProduct(productName, quantity);
                    if (newProduct != null)
                    {
                        inventory.TryAdd(productName, newProduct);
                    }
                }

            }
            catch (Exception ex)
            {
                
            }
        }
        public bool DecrementProductQuantity(string productName, int quantity)
        {
            try
            {
                //lock (_lock) // here instead of locking the entire inventory, we can lock only the product
                //{
                    inventory.TryGetValue(productName, out Product product);
                    if (product == null)
                    {
                        return false;
                    }
                    lock (product)
                    {
                        if (product.Quentity >= quantity)
                        {
                            product.Quentity -= quantity;
                            return true;
                        }
                    }
                    return false;
                //}
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Product GetProduct(string productName)
        {
            inventory.TryGetValue(productName, out Product product);
            return product;
        }
        public void PrintInventory()
        {
            Console.WriteLine("Inventory:-");
            foreach (var item in inventory)
            {
                Console.WriteLine($"Product:- {item.Key} Quantity:- {item.Value.Quentity}");
            }
        }
    }
}
