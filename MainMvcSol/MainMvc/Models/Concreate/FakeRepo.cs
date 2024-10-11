using MainMvc.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainMvc.Models.Concreate
{
    public class FakeRepo: ICustomerDal
    {
        static List<Customer> customerList = new List<Customer>();

        static FakeRepo()
        {
            customerList.Add(new Customer { ID = 111, CustName = "Cat", CatId = 10 });
            customerList.Add(new Customer { ID = 112, CustName = "Dog", CatId = 20 });
            customerList.Add(new Customer { ID = 113, CustName = "Buffalo", CatId = 30 });
            customerList.Add(new Customer { ID = 114, CustName = "Donkey", CatId = 10 });
            customerList.Add(new Customer { ID = 115, CustName = "Dumb", CatId = 20 });
        }

        public bool AddCustomer(Customer customer)
        {
            customerList.Add(customer);
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            var cust = customerList.Where(x => x.ID == id).FirstOrDefault();
            return customerList.Remove(cust);
        }

        public Customer Get(int id)
        {
            var cust = customerList.Where(x => x.ID == id).FirstOrDefault();
            return cust;
        }

        public IEnumerable<Customer> GetAll()
        {
            return customerList;
        }

        public bool UpdateCustomer(Customer customer)
        {
            var cust = customerList.Where(x => x.ID==customer.ID).FirstOrDefault();
            cust.CustName = customer.CustName;
            cust.CatId = customer.CatId;

            return true;
        }
    }
}