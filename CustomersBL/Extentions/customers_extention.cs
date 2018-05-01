using csutomers.Model;
using CustomersDAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersBL.Extentions
{
    public static class customers_extention
    {
        public static List<CustomerModel> ToModel(this List<Customer> dalCustomers)
        {
            List<CustomerModel> retList = new List<CustomerModel>();
            dalCustomers.ForEach(cust =>
            {
                retList.Add(cust.ToModel());
            });

            return retList;
        }
        public static CustomerModel ToModel(this Customer dalCustomer)
        {
            CustomerModel ret = new CustomerModel()
            {
                id = dalCustomer.Id
                , name = string.Format("{0} {1}", dalCustomer.LName, dalCustomer.FName)
            };
           

            return ret;
        }
    }
}
