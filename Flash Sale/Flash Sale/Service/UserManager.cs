using Flash_Sale.Entity;
using System.Collections.Concurrent;

namespace Flash_Sale.Service
{
    //singleton class
    public class UserManager
    {
        private ConcurrentDictionary<string,User> users;
        private static UserManager _instance;
        private static readonly Object _lock = new Object();
        private UserManager()
        {
            users = new ConcurrentDictionary<string, User>();
        }
        public static UserManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserManager();
                    }
                }
            }
            return _instance;
        }
        public void AddUser(string userName)
        {
            try
            {
                //use UserFactory to create user
                if(IsUserExist(userName))
                {
                    Console.WriteLine("User already exist");
                    return;
                }
                User newUser = new User(userName);
                users.TryAdd(userName, newUser);
            }
            catch (Exception ex)
            {
            }
        }
        public bool IsUserExist(string userName)
        {
            return users.ContainsKey(userName);
        }
        public void RemoveUser(string userName)
        {
            try
            {
                users.TryRemove(userName, out User user);
            }
            catch (Exception ex)
            {

            }
        }
        public User GetUser(string userName)
        {
            users.TryGetValue(userName, out User user);
            return user;
        }
        public bool CreateOrder(string userName, Product product, int quantity)
        {
            try
            {
                return OrderManager.GetInstance().CreateOrder(userName, product, quantity);
            }
            catch(Exception ex)
            {
                return false;
            }   
        }

    }
}
