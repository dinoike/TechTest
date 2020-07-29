using AnyCompany.Core.Models;
using AnyCompany.Core.Repository;

namespace AnyCompany.Core.Service
{
    public class OrderService: IOrderService
    {
        private readonly OrderRepository orderRepository = new OrderRepository();

        public bool PlaceOrder(Order order)
        {
            Customer customer = CustomerRepository.Load(order.CustomerId);

            if (order.Amount == 0)
                return false;

            if (customer.Country == "UK")
                order.VAT = 0.2d;
            else
                order.VAT = 0;

            orderRepository.Save(order);

            return true;
        }

        public CustomerOrder GetCustomerOrders(int customerId) 
        {
            CustomerOrder customerOrders = new CustomerOrder();

            Customer customer = CustomerRepository.Load(customerId);

            customerOrders.Name = customer.Name;
            customerOrders.Country = customer.Country;
            customerOrders.DateOfBirth = customer.DateOfBirth;

            customerOrders.Orders = orderRepository.Get(customerId);

            return customerOrders;
        }
    }
}
