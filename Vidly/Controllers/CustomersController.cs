using System;
using System.Collections.Generic;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id==id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel() 
            {
                MembershipTypes = membershiptypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel 
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.id == customer.id);
                customerInDb.Name = customer.Name;
                customerInDb.birthdate = customer.birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel 
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }
    }
}