using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQL29Project;

namespace SQL29_Test
{
    [TestClass]
    public class UnitTest1
    {

        CustomerDAO customerDAO;
        Customer c1, c2,c3,c4,c5;
        List<Customer> customers;


        public UnitTest1()
        {
             customerDAO = new CustomerDAO();
             c1 = new Customer
            {
                Id = 1,
                FristName = "a",
                LastName = "a",
                Age = 34,
                AddressCity = "a",
                AddressStreet = "a",
                PhNumber = "123"
            };

             c2 = new Customer
            {
                Id = 2,
                FristName = "b",
                LastName = "b",
                Age = 32,
                AddressCity = "b",
                AddressStreet = "b",
                PhNumber = "321"
            };

            c3 = new Customer
            {
                Id = 3,
                FristName = "aa",
                LastName = "aa",
                Age = 10,
                AddressCity = "b",
                AddressStreet = "aa",
                PhNumber = "1230"
            };

            c4 = new Customer
            {
                Id = 4,
                FristName = "bb",
                LastName = "bb",
                Age = 31,
                AddressCity = "b",
                AddressStreet = "bb",
                PhNumber = "3210"
            };
            c5 = new Customer
            {
                Id = 11,
                FristName = "az",
                LastName = "az",
                Age = 34,
                AddressCity = "za",
                AddressStreet = "az",
                PhNumber = "12378"
            };

            customers = new List<Customer>();
            customers.Add(c1);
            customers.Add(c2);
            customers.Add(c3);
            customers.Add(c4);


        }


        [TestMethod]
        //check GetAllCustomers() return all custumers
        public void TestIfGetAllCustomersReturnTheCustomersFromTheTable()
        {
            List<Customer> customersFromFunction = new List<Customer>();

            customersFromFunction = customerDAO.GetAllCustomers();

         Assert.AreEqual( customers.Count, customersFromFunction.Count);

            if (customers.Count == customersFromFunction.Count)
            {
                for (int i = 0; i < customers.Count; i++)

                {
                    Assert.IsTrue(customers[i] == customersFromFunction[i]);

                }
            }



        }
        [TestMethod]
        // now we check if we can get custumer  by it id
        public void TestIfGetCustomerByIdReturnTheCustomerFromTheTable()
        {
            Customer customerFromFunction = customerDAO.GetCustomerById(1);
            Assert.AreEqual(customers[0].Id , customerFromFunction.Id);

             customerFromFunction = customerDAO.GetCustomerById(2);
            Assert.AreEqual(customers[1].Id, customerFromFunction.Id);

            //check that the function return null if the customer doesnt exsit
            customerFromFunction = customerDAO.GetCustomerById(324445);
            Assert.IsNull(customerFromFunction);




        }
        [TestMethod]

        public void TestUpdateCustomer()
        {
            if (customerDAO.GetCustomerById(2) == null)
                customerDAO.AddCustomer(c2);
            //delete custumer with id 1
            customerDAO.UpdateCustomer(2, c5);
            //check that it doesnt exist 
            Assert.AreEqual(customerDAO.GetCustomerById(11).Id,c5.Id);



            // update it back to what it was before
            customerDAO.UpdateCustomer(11, c2);


        }
        [TestMethod]
        // now we check if we can get custumer  by its phone number
        public void TestIfGetCustomerByPhoneNumberReturnTheCustomerFromTheTable()
        {
            Customer customerFromFunction = customerDAO.GetCustomerByPhoneNumber("123");
            Assert.IsTrue(customers[0] == customerFromFunction);

            customerFromFunction = customerDAO.GetCustomerByPhoneNumber("321");
            Assert.IsTrue(customers[1] == customerFromFunction);
            
            //check that the function return null if the customer doesnt exsit
            customerFromFunction = customerDAO.GetCustomerByPhoneNumber("324445");
            Assert.IsNull(customerFromFunction);

        }

        // now we check if we can get custumer  by  LivinigInCity
        [TestMethod]

        public void TestGetCustomersLivinigInCity()
        {

            List<Customer> customersFromFunction = new List<Customer>();

            customersFromFunction = customerDAO.GetCustomersLivinigInCity("b");

            // there three customers in the database that live in a- and thay are The last three in customers

            Assert.AreEqual(customersFromFunction.Count, 3);

            if (customers.Count == customersFromFunction.Count)
            {
                
                for (int i = 1; i < 4; i++)

                {
                    Assert.IsTrue(customers[i] == customersFromFunction[i]);

                }
            }

            //check if work when the value doesnt exist
            customersFromFunction = customerDAO.GetCustomersLivinigInCity("p");

            // there three customers in the database that live in a- and thay are The last three in customers

            Assert.AreEqual(customersFromFunction.Count, 0);



        }



        // now we check if we can get custumer  BetweenAges
        [TestMethod]

        public void TestGetCustomersBetweenAges()
        {

            List<Customer> customersFromFunction = new List<Customer>();

            customersFromFunction = customerDAO.GetCustomersBetweenAges(32,35);

            // there two customers in the database that there agw between 32-35- 
            //and thay are The first two in customers

            Assert.AreEqual(customersFromFunction.Count, 2);

            if (customers.Count == customersFromFunction.Count)
            {

                for (int i = 0; i < 2; i++)

                {
                    Assert.IsTrue(customers[i] == customersFromFunction[i]);

                }
            }

            //check if work when the value doesnt exist
            customersFromFunction = customerDAO.GetCustomersBetweenAges(1,5);

            // there three customers in the database that live in a- and thay are The last three in customers

            Assert.AreEqual(customersFromFunction.Count, 0);



        }



       [TestMethod]
        //now we remove all the custumers;
        public void TestRemoveAllCustomers()
        {

            //add customer to insure the list doesnt empty
            //check if it work
            customerDAO.AddCustomer(c5);

           customerDAO.RemoveAllCustomers();
            Assert.AreEqual(customerDAO.GetAllCustomers().Count,0);
            // check if it work whan the list empty
            customerDAO.RemoveAllCustomers();
            Assert.AreEqual(customerDAO.GetAllCustomers().Count, 0);



        }

        //now we add tham back and check if AddCustomer work
        [TestMethod]

        public void TestAddCustomer()
        {
            //make sure that the database empty before we try addig customer
            TestRemoveAllCustomers();


            customerDAO.AddCustomer(c1);
            customerDAO.AddCustomer(c2);
            customerDAO.AddCustomer(c3);
            customerDAO.AddCustomer(c4);

            // if the test of TestIfGetAllCustomersReturnTheCustomersFromTheTable pass we can use that function to check if all the customers to the database
            TestIfGetAllCustomersReturnTheCustomersFromTheTable();



        }

        [TestMethod]
        [ExpectedException(typeof(SqliteException))]
        public void TestAddCustomerthatExist()
        {
            customerDAO.AddCustomer(c1);
         

            // if the test of TestIfGetAllCustomersReturnTheCustomersFromTheTable pass we can use that function to check if all the customers to the database

        }

        [TestMethod]

        public void TestDeleteCustomer()
        {
            //delete custumer with id 1
            customerDAO.DeleteCustomer(1);
            //check that it doesnt exist 
            Assert.IsNull(customerDAO.GetCustomerById(1));


            // add it back
            customerDAO.AddCustomer(c1);
           

        }
        
        

    }
}
