using System.Collections.Generic;

namespace SQL29Project
{
    interface ICustomerDAO
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer( Customer customer);
        void UpdateCustomer(int id,Customer customer);

        void DeleteCustomer(int id);
        List<Customer> GetCustomersLivinigInCity(string city);
        List<Customer> GetCustomersBetweenAges(int minAge, int maxAge);
        Customer GetCustomerByPhoneNumber(string phone);
        void RemoveAllCustomers();

    }
}
