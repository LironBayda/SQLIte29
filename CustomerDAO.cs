using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace SQL29Project
{
    public class CustomerDAO: ICustomerDAO
    {
        SqliteConnection connection;

        public CustomerDAO()
        {
          connection = new SqliteConnection($"Data Source = C:\\Users\\liron\\Downloads\\SQL29.db");

        }
        /*       CREATE TABLE "CUSTOMER" (
       "ID"	INTEGER NOT NULL,
       "FRIST_NAME"	TEXT NOT NULL ,
       "LAST_NAME"	TEXT NOT NULL ,
       "AGE"	INT NOT NULL,
       "ADDRESS_CITY"	CHAR(50),
       "ADDRESS_STREET"	CHAR(50),
       "PH_NUMBER" CHAR(50) UNIQUE,
       PRIMARY KEY("ID"))*/

        public void AddCustomer(Customer customer)
        {
            // creating conenction to the Sqlite database


           
                connection.Open();

                using (SqliteCommand cmd = new SqliteCommand($"INSERT INTO CUSTOMERS VALUES('{customer.Id}'," +
                    $"'{customer.FristName}','{customer.LastName}',{customer.Age},'{customer.AddressCity}' ,'{customer.AddressStreet}'," +
                    $"'{customer.PhNumber}')", connection))
                {
                     cmd.ExecuteNonQuery();

                }
            
            connection.Close();

        }

        public void DeleteCustomer(int id)
        {
            connection.Open();

            using (SqliteCommand cmd = new SqliteCommand($"DELETE FROM CUSTOMERS WHERE id={id}; ", connection))
            {
                cmd.ExecuteNonQuery();

            }

            connection.Close();

        }
        /*       CREATE TABLE "CUSTOMER" (
"ID"	INTEGER NOT NULL,
"FRIST_NAME"	TEXT NOT NULL ,
"LAST_NAME"	TEXT NOT NULL ,
"AGE"	INT NOT NULL,
"ADDRESS_CITY"	CHAR(50),
"ADDRESS_STREET"	CHAR(50),
"PH_NUMBER" CHAR(50) UNIQUE,
PRIMARY KEY("ID"))*/

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            connection.Open();

            using (SqliteCommand cmd = new SqliteCommand("SELECT * FROM CUSTOMERS", connection))
            {

                using (SqliteDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read() == true)
                    {

                    Customer c = new Customer
                        {
                        Id = Convert.ToInt32( reader["ID"]),
                            FristName =(string)reader["FRIST_NAME"],
                           LastName =(string)reader["LAST_NAME"],
                            Age = Convert.ToInt32(reader["AGE"]),
                            AddressCity = (string)reader["ADDRESS_CITY"],
                            AddressStreet = (string)reader["ADDRESS_STREET"],
                            PhNumber =(string)reader["PH_NUMBER"]
                        };

                        customers.Add(c);

                      //  Console.WriteLine(c.ToString());
                    }

                }
            }

            connection.Close();
            
            return customers;

        }
    

        public Customer GetCustomerById(int id)
        {
            connection.Open();

            using (SqliteCommand cmd = new SqliteCommand("SELECT * FROM CUSTOMERS", connection))
            {

                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                

                    while (reader.Read() == true)
                    {
  

                        Customer c = new Customer
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            FristName = (string)reader["FRIST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            Age = Convert.ToInt32(reader["AGE"]),
                            AddressCity = (string)reader["ADDRESS_CITY"],
                            AddressStreet = (string)reader["ADDRESS_STREET"],
                            PhNumber = (string)reader["PH_NUMBER"]
                        };

                        if (c.Id == id)
                        {
                            Console.WriteLine(c.ToString());
                            connection.Close();

                            return c;
                        }
                    }

                }
            }
            return null;

          
        }

        public Customer GetCustomerByPhoneNumber(string phone)
        {
            connection.Open();

            using (SqliteCommand cmd = new SqliteCommand("SELECT * FROM CUSTOMERS", connection))
            {

                using (SqliteDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read() == true)
                    {
 

                        Customer c = new Customer
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            FristName = (string)reader["FRIST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            Age = Convert.ToInt32(reader["AGE"]),
                            AddressCity = (string)reader["ADDRESS_CITY"],
                            AddressStreet = (string)reader["ADDRESS_STREET"],
                            PhNumber = (string)reader["PH_NUMBER"]
                        };

                        if (c.PhNumber== phone)
                        {
                            Console.WriteLine(c.ToString());
                            connection.Close();

                            return c;
                        }
                    }

                }
            }
            connection.Close();

            return null;
        }

        public List<Customer> GetCustomersBetweenAges(int minAge, int maxAge)
        {
            List<Customer> customers = new List<Customer>();
            connection.Open();

            using (SqliteCommand cmd = new SqliteCommand("SELECT * FROM CUSTOMERS", connection))
            {

                using (SqliteDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read() == true)
                    {


                        Customer c = new Customer
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            FristName = (string)reader["FRIST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            Age = Convert.ToInt32(reader["AGE"]),
                            AddressCity = (string)reader["ADDRESS_CITY"],
                            AddressStreet = (string)reader["ADDRESS_STREET"],
                            PhNumber = (string)reader["PH_NUMBER"]
                        };

                        if (c.Age >= minAge && c.Age <= maxAge)
                        {
                            customers.Add(c);

                            Console.WriteLine(c.ToString());
                        }
                    }

                }
            }

            connection.Close();

            return customers;
        }

        public List<Customer> GetCustomersLivinigInCity(string city)
        {
            List<Customer> customers = new List<Customer>();
            connection.Open();

            using (SqliteCommand cmd = new SqliteCommand("SELECT * FROM CUSTOMERS", connection))
            {

                using (SqliteDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read() == true)
                    {


                        Customer c = new Customer
                        {
                            Id = Convert.ToInt32(reader["ID"]),
                            FristName = (string)reader["FRIST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            Age = Convert.ToInt32(reader["AGE"]),
                            AddressCity = (string)reader["ADDRESS_CITY"],
                            AddressStreet = (string)reader["ADDRESS_STREET"],
                            PhNumber = (string)reader["PH_NUMBER"]
                        };

                        if (c.AddressCity == city)
                        {
                            customers.Add(c);

                         //   Console.WriteLine(c.ToString());
                        }
                    }

                }
            }

            connection.Close();

            return customers;
        }

        public void RemoveAllCustomers()
        {

            connection.Open();

            using (SqliteCommand cmd = new SqliteCommand($"DELETE FROM CUSTOMERS", connection))
            {
                cmd.ExecuteNonQuery();

            }

        connection.Close();   
        }

        public void UpdateCustomer(int id, Customer customer)
        {

            connection.Open();

            using (SqliteCommand cmd = new SqliteCommand($"UPDATE  CUSTOMERS SET " +
                $"ID='{customer.Id}', FRIST_NAME='{customer.FristName}',LAST_NAME='{customer.LastName}',AGE={customer.Age},ADDRESS_CITY='{customer.AddressCity}' ,ADDRESS_STREET='{customer.AddressStreet}'," +
                $"PH_NUMBER={customer.PhNumber} WHERE ID={id}", connection))
            {
                cmd.ExecuteNonQuery();

            }

            connection.Close();
        }

        public List<Customer> GetCustomerByPhoneNumberLINQ(List<Customer> customers,string phoneNumber)
        {
            List<Customer> customersResult = new List<Customer>();

          customers.Where(x => x.PhNumber == phoneNumber).ToList().ForEach(x => { customersResult.Add(x); }); ;

            return customersResult;


        }
        public List<Customer> GetCustomerBetweenAgesLINQ(List<Customer> customers, int minAge, int maxAge)
        {
            List<Customer> customersResult = new List<Customer>();

            customers.Where(x => x.Age >= minAge && x.Age<= maxAge).ToList().ForEach(x => { customersResult.Add(x); }); ;

            return customersResult;

        }
            public List<Customer> GetCustomerLivingInCityLINQ(List<Customer> customers, string city)
        {
            List<Customer> customersResult = new List<Customer>();

            customers.Where(x => x.AddressCity ==city).ToList().ForEach(x => { customersResult.Add(x); }); ;

            return customersResult;

        }
    public Customer GetCustomerByIdLINQ(List<Customer> customers, int id)
        {
            Customer customerResult = new Customer();

             customerResult = customers.Where(x => x.Id == id).First();

            return customerResult;

        }

        public void AddTable()
        {
            // creating conenction to the Sqlite database



            connection.Open();

            using (SqliteCommand cmd = new SqliteCommand($"CREATE TABLE IF NOT EXISTS some_table (id INTEGER PRIMARY KEY AUTOINCREMENT, AGE INTEGER, name TEXT)" , connection))
            {
                cmd.ExecuteNonQuery();

            }

            connection.Close();

        }



    }
}
