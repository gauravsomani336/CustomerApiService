using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        static IList<Customer> Customers = new List<Customer>()
        {
            new Customer()
                {
                   CustomerId = 1,CustomerName = "Mukesh Kumar", Address = "New Delhi", State = "IT"
                },
                new Customer()
                {
                    CustomerId = 2, CustomerName = "Banky Chamber", Address = "London", State = "HR"
                },
                new Customer()
                {
                   CustomerId = 3, CustomerName = "Rahul Rathor", Address = "Laxmi Nagar", State = "IT"
                },
                new Customer()
                {
                    CustomerId = 4,CustomerName = "YaduVeer Singh", Address = "Goa", State = "Sales"
                },
                new Customer()
                {
                   CustomerId = 5, CustomerName = "Manish Sharma", Address = "New Delhi", State = "HR"
                },
        };
        [HttpGet()]
        public IList<Customer> GetAllCustomers()
        {
            //Return list of all customers    
            return Customers;
        }
     


        [HttpGet("{id}")]
        public Customer GetCustomerDetails(int id)
        {
            //Return a single customer detail    
            var Customer = Customers.FirstOrDefault(e => e.CustomerId == id);

            return Customer;
        }


        [HttpPost]
        public bool PostCustomerDetails([FromBody]Customer customer)
        {
            Customers.Add(customer);

            return true;
        }
        [HttpPut]
        public bool PutStudentDetails([FromBody] Customer customer)
        {
            var Student = Customers.FirstOrDefault(e => e.CustomerId == customer.CustomerId);
            Student.CustomerName = customer.CustomerName;
            Student.Address = customer.Address;
            Student.State = customer.State;
            return true;
        }
        [HttpDelete("{id:int}")]
        public bool DeleteCustomerDetails(int id)
        {
            var Customer = Customers.FirstOrDefault(e => e.CustomerId == id);
            Customers.Remove(Customer);

            return true;
        }
    }

}
