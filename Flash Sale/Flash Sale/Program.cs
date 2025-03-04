//create user
using Flash_Sale.Service;

UserManager.GetInstance().AddUser("user1");
UserManager.GetInstance().AddUser("user2");
UserManager.GetInstance().AddUser("user3");

//create product
Inventory.GetInstance().AddProduct("product1", 5);
Inventory.GetInstance().AddProduct("product2", 2);
Inventory.GetInstance().AddProduct("product3", 3);

Inventory.GetInstance().PrintInventory();

//create order
Thread t1 = new Thread(() => UserManager.GetInstance().CreateOrder("user1", Inventory.GetInstance().GetProduct("product1"), 2));
Thread t2 = new Thread(() => UserManager.GetInstance().CreateOrder("user1", Inventory.GetInstance().GetProduct("product2"), 1));
Thread t3 = new Thread(() => UserManager.GetInstance().CreateOrder("user2", Inventory.GetInstance().GetProduct("product2"), 1));
Thread t4 = new Thread(() => UserManager.GetInstance().CreateOrder("user3", Inventory.GetInstance().GetProduct("product2"), 1));
Thread t5 = new Thread(() => UserManager.GetInstance().CreateOrder("user3", Inventory.GetInstance().GetProduct("product1"), 2));

t1.Start();
t2.Start();
t3.Start();
t4.Start();
t5.Start();

Task[] tasks = new Task[5];

tasks[0] = Task.Run(() => UserManager.GetInstance().CreateOrder("user1", Inventory.GetInstance().GetProduct("product1"), 3));

tasks[1] = Task.Run(()=>UserManager.GetInstance().CreateOrder("user1", Inventory.GetInstance().GetProduct("product2"), 1));
tasks[2] = Task.Run(() => UserManager.GetInstance().CreateOrder("user2", Inventory.GetInstance().GetProduct("product2"), 1));
tasks[3] = Task.Run(() => UserManager.GetInstance().CreateOrder("user3", Inventory.GetInstance().GetProduct("product2"), 1));
tasks[4] = Task.Run(() => UserManager.GetInstance().CreateOrder("user3", Inventory.GetInstance().GetProduct("product1"), 3));

t1.Join();
t2.Join();
t3.Join();
t4.Join();
t5.Join();
Task.WhenAll(tasks).Wait();

Inventory.GetInstance().PrintInventory();
Console.WriteLine("completed...");

