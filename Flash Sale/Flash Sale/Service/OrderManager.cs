using Flash_Sale.Entity;
using System.Collections.Concurrent;

namespace Flash_Sale.Service
{
    //singleton class
    public class OrderManager
    {
        private ConcurrentDictionary<string,List<Order>> _orders;
        int totalOrders;
        private static OrderManager _instance;
        private static readonly Object _lock = new Object();
        private OrderManager() 
        {
            _orders = new ConcurrentDictionary<string, List<Order>>();
            totalOrders = 0;
        }
        public static OrderManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new OrderManager();
                    }
                }
            }
            return _instance;
        }
        public bool CreateOrder(string userName, Product product, int quantity)
        {
            try
            {
                Console.WriteLine($"trying to create order for user:- {userName} and product:- {product.ProductName} and quantity:- {quantity}  ");

                // create order from order factory
                Order newOrder = OrderFactory.CreateOrder(++totalOrders, product, quantity);
                if (newOrder != null)
                {
                    //decrement product quantity from inventory
                    if (Inventory.GetInstance().DecrementProductQuantity(product.ProductName, quantity))
                    {
                        Console.WriteLine($"order created successfully for user:- {userName} and product:- {product.ProductName} and quantity:- {quantity}  ");

                        if (_orders.ContainsKey(userName))
                        {
                            _orders[userName].Add(newOrder);
                        }
                        else
                        {
                            _orders.TryAdd(userName, new List<Order> { newOrder });
                        }
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"order doesn't created for user:- {userName} and product:- {product.ProductName} and quantity:- {quantity}  ");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"order doesn't created for user:- {userName} and product:- {product.ProductName} and quantity:- {quantity}  ");
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
