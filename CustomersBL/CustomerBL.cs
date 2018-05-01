using csutomers.Model;
using CustomersDAL.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomersBL.Extentions;

namespace CustomersBL
{
    public class CustomerBL
    {
        public List<CustomerModel> getAllCustomers() {
            using(var uow=new SqlUnitOfWork())
            {
                var customers_repository = uow.Customers;
                var customers = customers_repository.FindAll().ToList();

                return customers.ToModel();
            }
        }
    }
}
