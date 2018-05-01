using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinSelfhostSample
{
    [RoutePrefix("api/customers")]
    public class CustomersController: ApiController
    {
        private List<CustomerModel> customers;
        private void _init_customers() {
            this.customers=new List<CustomerModel>() {
                
  {
    id: "1",
    name: "cust 1"
  },
                {
                    id: "2",
                    name: "cust 2"
                },
                {
                    id: "3",
                    name: "cust 3"
                },
                {
                    id: "4",
                    name: "cust 4"
                }


            }
        }
        public CustomersController()
        {
            _init_customers();
        }
        // GET api/values 
        [HttpGet]
        [Route("Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
