using Contracts;
using Model;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {

        IRepositoryBase<Customer> _customers;
        IRepositoryBase<Product> _products;
        //Constructor
        public CustomerController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products)
        {
            _customers = customers;
            _products = products;
        }

        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Lists products
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomersList()
        {
            // get all products and pass to view
            var model = _customers.GetAll();

            return View(model);
        }

        public ActionResult CreateCustomer()
        {

            return View(new Customer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(Customer u)
        {
            


            _customers.Insert(u);
            _customers.Save();
            return View();

        }

        public ActionResult DetailsCustomer(int id)
        {

            return View(_customers.GetByID(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DetailsCustomer(Customer u)
        {

            return View(u);

        }

        public ActionResult EditCustomer(int id)
        {

            return View(_customers.GetByID(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "CustomerId,CustomerName,Address")] Customer u)
        {  
            
            _customers.Update(u);
            _customers.Save();
            return View("Index");


        }


        public ActionResult DeleteCustomer(int id)
        {

            _customers.Delete(_customers.GetByID(id));
            _customers.Save();
            return View();

            //return View("Create", new ProductInput().InjectFrom(repo.Get(id)));
        }




    }
}