using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL29Project
{
    public class Customer
    {
        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public string PhNumber { get; set; }

        public override string ToString()
        {
            return base.ToString() + JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public Customer()
        {

        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            if (Object.ReferenceEquals(customer1, null) && Object.ReferenceEquals(customer1, null))
                return true;
            else if (Object.ReferenceEquals(customer1, null) || Object.ReferenceEquals(customer1, null))
                return false;
                return customer1.Id == customer2.Id;
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(customer1== customer2);
        }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            if (customer!= null)
            return this.Id == customer.Id;

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
