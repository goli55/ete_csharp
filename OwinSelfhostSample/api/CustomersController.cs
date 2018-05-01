using csutomers.Model;
using CustomersBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinSelfhostSample
{
    [RoutePrefix("api/customers")]
    public class CustomersController: ApiController
    {

        private List<CustomerModel> customers;
        private void _init_customers_demo()
        {
            this.customers = new List<CustomerModel>() {

  new CustomerModel(){
    id=1,
    name= "cust 1"
  },
               new CustomerModel() {
                    id= 2,
                    name= "cust 2"
                },
                new CustomerModel(){
                    id= 3,
                    name= "cust 3"
                },
                new CustomerModel(){
                    id= 4,
                    name= "cust 4"
                }


            };
        }
        public CustomersController()
        {
           
        }

       

        // GET api/values 
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            try
            {
                var bl = new CustomerBL();
                var data = bl.getAllCustomers();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK,data);
               // response.Content = data;// new StringContent("hell, Encoding.Unicode);

                return response;

                
            }
            catch(Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.ExpectationFailed, ex.Message);
               
                return response;
                //return new HttpResponseMessage(System.Net.HttpStatusCode.ExpectationFailed);
            }
        }
    }
}
