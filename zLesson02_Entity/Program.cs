using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zLesson02_Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var context = Connect();
            //ChangeUserInfo(context, "Женя С.", "Женя Сдерж.");
            //var customers = GetCustomers0(context);
            //foreach (var item in customers)
            //{
            //    Console.WriteLine("ID: {0} \t Name: {1} \t Phone: {2}", item.Id, item.CustomerName, item.CustomerPhone);
            //}
            AddRows(context);
            //GetOrderDetailsByInclude(context);
            GetClientProducts(context);
            Console.Write("Press mazafaka Enter to exit...");
            Console.ReadLine();
        }
        private static void AddRows(testDB_01Entities context)
        {
            Console.WriteLine("EF adding rows...");
            Customer newCustomer = new Customer { CustomerName = "Паша М.", CustomerPhone = "19" };
            context.TCustomers.Add(newCustomer );
            Console.WriteLine("ID of new user {0} is {1}", newCustomer.Id, newCustomer.CustomerName);
            Order newOrder = new Order { Customer = newCustomer, CreateDate = DateTime.Now};
            context.TOrders.Add(newOrder);
            Console.WriteLine("ID of new order at {0} is {1}", newOrder.CreateDate, newOrder.Id);
            Product product = context.TProducts.First();
            // Product product = context.TProducts.Single(c => c.Id == 5);
            ProductInOrder productInOrder = context.TProductsInOrders.Add(new ProductInOrder { Order = newOrder, Product = product, Count = 2 });

            Console.WriteLine("... Ready\n");
            Console.WriteLine("EF is saving changes...");
            context.SaveChanges();
            Console.WriteLine("... Ready\n");
        }

        private static void ChangeUserInfo(testDB_01Entities context, int id, string newName)
        {
            try
            {
                Console.WriteLine("EF is updating row with id={0}...", id);
                var customer = context.TCustomers.Single(c => c.Id == id);
                customer.CustomerName = newName;
                Console.WriteLine("... Ready\n");
                Console.WriteLine("EF is saving changes...");
                context.SaveChanges();
                Console.WriteLine("... Ready\n");
            } 
            catch
            {
                Console.WriteLine("Entry with id={0} is not found in database", id);
            }
        }
        private static void ChangeUserInfo(testDB_01Entities context, string oldName, string newName)
        {
            try
            {
                Console.WriteLine("EF is updating row with name={0}...", oldName);
                var customer = context.TCustomers.Single(c => c.CustomerName == oldName);
                customer.CustomerName = newName;
                Console.WriteLine("... Ready\n");
                Console.WriteLine("EF is saving changes...");
                context.SaveChanges();
                Console.WriteLine("... Ready\n");
            }
            catch
            {
                Console.WriteLine("Entry with name={0} is not found in database", oldName);
            }
        }

        private static void GetOrderDetailsByInclude(testDB_01Entities context)
        {
            Console.WriteLine("EF is executing query...");
            var customers = context.TCustomers.Include("Orders")
                .Include("Orders.ProductsInOrder")
                .Include("Orders.ProductsInOrder.Product");
            Console.WriteLine("... Ready\n");
            foreach (var customer in customers)
            {
                Console.WriteLine("{0}:", customer.CustomerName.Trim());
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\tOrder from {0}", order.CreateDate.ToString("dd.MM.yyyy"));
                    foreach (var product in order.ProductsInOrder)
                    {
                        Console.WriteLine("\t\t{0} - {1} pcs.", product.Product.ProductName.Trim(), product.Count);
                    }
                }
            }

        }
        private static void GetClientProducts(testDB_01Entities context)
        {
            var query = from c in context.TCustomers
                        join o in context.TOrders on c.Id equals o.CustomerId into go
                        from oJoined in go.DefaultIfEmpty()

                        join po in context.TProductsInOrders on oJoined.Id equals po.OrderId into gpo
                        from poJoined in gpo.DefaultIfEmpty()

                        join p in context.TProducts on poJoined.ProductId equals p.Id into gp
                        from pJoined in gp.DefaultIfEmpty()

                        select new
                        {
                            CustomerName = c.CustomerName,
                            ProductName = pJoined == null ? "" : pJoined.ProductName,
                            ProductCount = poJoined == null ? 0 : poJoined.Count
                        };

            Console.WriteLine("{0,15} {1,30} {2,8}", "Name", "Product", "Count");
            var list = query.ToList();
            foreach (var item in list)
            {
                Console.WriteLine("{0,15} {1,30} {2,8}", item.CustomerName.Trim(), item.ProductName.Trim(), item.ProductCount);
            }
        }
        private static void GetOrderDetailsByJoins(testDB_01Entities context)
        {
            Console.WriteLine("EF is executing query...");
            var query = from c in context.TCustomers
                        join o in context.TOrders on c.Id equals o.CustomerId
                        join po in context.TProductsInOrders on o.Id equals po.OrderId
                        join p in context.TProducts on po.ProductId equals p.Id
                        orderby o.CreateDate
                        select new
                        {
                            OrderNumber = o.Id,
                            OrderDate = o.CreateDate,
                            CustomerName = c.CustomerName,
                            ProductName = p.ProductName,
                            ProductCount = po.Count,
                            ProductPrice = p.ProductPrice
                        };
            Console.WriteLine("... Ready\n");
            Console.WriteLine("{0,6} {1,22} {2,17} {3,30} {4,8} {5,8} {6,8}", 
                "Ord. #", "Order date", "Customer name", "Product name", "Count", "Price", "Cost");
            //PrintSpec("Ord. #", "Order date", "Customer name", "Product name", "Count", "Price", "Cost");
            int prevID = 0;
            int summ = 0;
            foreach (var item in query)
            {
                var ordID = new StringBuilder("");
                var ordDate = new StringBuilder("");
                var custName = new StringBuilder("");
                if (item.OrderNumber != prevID)
                {
                    ordID.Append(item.OrderNumber);
                    ordDate.Append(item.OrderDate);
                    custName.Append(item.CustomerName.Trim());
                    if (prevID != 0)
                        PrintSumm(summ);
                    summ = 0;
                }
                summ += (item.ProductCount * item.ProductPrice);
                Console.WriteLine("{0,6} {1,22} {2,17} {3,30} {4,8} {5,8} {6,8}", 
                    ordID, ordDate, custName, item.ProductName.Trim(), item.ProductCount.ToString(), item.ProductPrice.ToString(), (item.ProductCount * item.ProductPrice));
                //PrintSpec(ordID.ToString(), ordDate.ToString(), custName.ToString(), item.ProductName.Trim(),
                //    item.ProductCount.ToString(), item.ProductPrice.ToString());
                prevID = item.OrderNumber;
            }
            PrintSumm(summ);
        }
        private static void PrintSumm(int summ)
        {
            Console.WriteLine("{0, 6} {1, 6}", "  TOTAL SUMM: ", summ.ToString());
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        }
        private static void PrintSpec(params string[] strPar)
        {
            Console.WriteLine("{0,6} {1,22} {2,17} {3,30} {4,8} {5,8} {6,8}", 
                strPar[0], strPar[1], strPar[2], strPar[3], strPar[4], strPar[5], strPar[6]);
        }
        private static List<Customer> GetCustomers3(testDB_01Entities context)
        {
            Console.WriteLine("EF is selecting customers list...");
            var query = from c in context.TCustomers
                where c.Id == 1
                select c;
            List<Customer> result = query.ToList();
            Console.WriteLine("... Ready");
            return result;
        }   
        private static List<Customer> GetCustomers2(testDB_01Entities context)
        {
            IEnumerable<Customer> query = (context.TCustomers as IEnumerable<Customer>).Where(c => c.Id == 1);
            List<Customer> result = query.ToList();
            Console.WriteLine("... Ready");
            return result;
        }
        private static List<Customer> GetCustomers1 (testDB_01Entities context)
        {
            Console.WriteLine("EF is selecting customers list...");
            IQueryable<Customer> query = context.TCustomers.Where(c => c.Id == 1); ;
            List<Customer> result = query.ToList();
            Console.WriteLine("... Ready");
            return result;
        }
        private static List<Customer> GetCustomers0(testDB_01Entities context)
        {
            Console.WriteLine("EF is selecting customers list...");
            List<Customer> result = context.TCustomers.ToList();
            Console.WriteLine("... Ready");
            return result;
        }
        private static testDB_01Entities Connect()
        {
            Console.WriteLine("EF is connecting to DB...");
            var context = new testDB_01Entities();
            Console.WriteLine("... Ready");
            return context;
        }
    }
}
