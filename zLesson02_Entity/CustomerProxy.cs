using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zLesson02_Entity
{
    internal class CustomerProxy
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public static void PrintCustomers(List<CustomerProxy> _list)
        {
            foreach (var item in _list)
            {
                Console.WriteLine("ID: {0} \t Name: {1} \t Phone: {2}", item.CustomerId, item.CustomerName, item.CustomerPhone);
            }
        }
    }
}
