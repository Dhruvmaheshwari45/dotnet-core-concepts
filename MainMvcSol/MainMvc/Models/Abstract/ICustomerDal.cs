using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMvc.Models.Abstract
{
    internal interface ICustomerDal
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);
    }
}
