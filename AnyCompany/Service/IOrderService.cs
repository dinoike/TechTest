using AnyCompany.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Core.Service
{
    public interface IOrderService
    {
        bool PlaceOrder(Order order);
        CustomerOrder GetCustomerOrders(int customerId);
    }
}
