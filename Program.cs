using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL29Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer
            {
                Id = 1,
                FristName = "a",
                LastName = "a",
                Age = 34,
                AddressCity = "a",
                AddressStreet = "a",
                PhNumber = "123"
            };

            Customer c2 = new Customer
            {
                Id = 2,
                FristName = "b",
                LastName = "b",
                Age = 32,
                AddressCity = "b",
                AddressStreet = "b",
                PhNumber = "321"
            };

            Customer c3 = new Customer
            {
                Id = 3,
                FristName = "aa",
                LastName = "aa",
                Age = 10,
                AddressCity = "b",
                AddressStreet = "aa",
                PhNumber = "1230"
            };

            Customer c4 = new Customer
            {
                Id = 4,
                FristName = "bb",
                LastName = "bb",
                Age = 31,
                AddressCity = "b",
                AddressStreet = "bb",
                PhNumber = "3210"
            };


            CustomerDAO customerDAO = new CustomerDAO();

        //    customerDAO.AddCustomer(c1);
            //   customerDAO.UpdateCustomer(1, c1);
           // customerDAO.AddCustomer(c2);
           // customerDAO.AddCustomer(c3);
          //  customerDAO.AddCustomer(c4);

            //  customerDAO.DeleteCustomer(6);
            //
            List<Customer> customers = new List<Customer>();
            customers = customerDAO.GetAllCustomers();

            //     Console.WriteLine("phone");

            //  customerDAO.GetCustomerByPhoneNumber("57862963794");

            //    Console.WriteLine("age");

            //   customerDAO.GetCustomersBetweenAges(30, 40);

            //   Console.WriteLine("city");

            //   customerDAO.GetCustomersLivinigInCity("a");
            //    customerDAO.RemoveAllCustomers();

            CustomerDAO customerDAOResult = new CustomerDAO();

            Console.WriteLine(customerDAO.GetCustomerByPhoneNumberLINQ(customers, "123")[0].ToString());

            Console.WriteLine(customerDAO.GetCustomerBetweenAgesLINQ(customers, 1, 10)[0].ToString());

            Console.WriteLine(customerDAO.GetCustomerByIdLINQ(customers,2).ToString());

            customerDAO.AddTable();
            
            Console.ReadLine();
        }
        
    }
}
