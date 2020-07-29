using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Core.Models
{
    public class CustomerOrder : Customer
    {
        public CustomerOrder()
        {
            Orders = new List<Order>();
        }

        public List<Order> Orders { get; set; }
    }
}
