using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainMvc.Models.Abstract
{
    public class Customer
    {
        public int ID { get; set; }
        public string CustName { get; set; }

        public int CatId { get; set; }
    }
}