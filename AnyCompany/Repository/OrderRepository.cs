using AnyCompany.Core.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AnyCompany.Core.Repository
{
    internal class OrderRepository : IOrderRepository
    {
        private static string ConnectionString = @"Data Source=(local);Database=Orders;User Id=admin;Password=password;";

        public void Save(Order order)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@OrderId, @Amount, @VAT,@CustomerId)", connection);

            command.Parameters.AddWithValue("@OrderId", order.OrderId);
            command.Parameters.AddWithValue("@Amount", order.Amount);
            command.Parameters.AddWithValue("@VAT", order.VAT);
            command.Parameters.AddWithValue("@CustomerId", order.CustomerId);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public List<Order> Get(int customerId)
        {
            List<Order> orders = new List<Order>();

            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            //NB : Assume that Orders table has customerid

            SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE CustomerId = " + customerId,
                connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                orders.Add(new Order
                {
                    OrderId = int.Parse(reader["OrderId"].ToString()),
                    Amount = double.Parse(reader["Amount"].ToString()),
                    VAT = double.Parse(reader["VAT"].ToString()),
                    CustomerId=int.Parse(reader["CustomerId"].ToString())
                }); ;              
            }

            connection.Close();

            return orders;
        }
    }
}
