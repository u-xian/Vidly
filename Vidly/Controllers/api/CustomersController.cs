using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        

        // GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            //return _context.Customers
            //    .Include(c => c.MemberShipType)
            //    .ToList()
            //    .Select(Mapper.Map<Customer,CustomerDtos>);

            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return customers;
        }

        //GET /api/customers/1

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDtos>(customer));
        }

        //POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDtos customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDtos, Customer>(customerdto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerdto.id = customer.id;

            return Created(new Uri(Request.RequestUri + "/" +customer.id),customerdto);
        }

        //PUT  /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDtos customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerdto,customerInDb);

            _context.SaveChanges();
        }

        //DELETE /api/customer/1

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
