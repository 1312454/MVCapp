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
    public class ProductController : Controller
    {

        IRepositoryBase<Customer> _customers;
        IRepositoryBase<Product> _products;
        IRepositoryBase<User> _users;
        //Constructor
        public ProductController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products)
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
        public ActionResult ProductsList()
        {
            // get all products and pass to view
            var model = _products.GetAll();

            return View(model);
        }

        public ActionResult CreateProduct()
        {

            return View(new Product());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CreateProduct(Product u)
        {
            //Create new Product
            //var model = new Product();

            
          
            _products.Insert(u);
            _products.Save();
            //ViewBag.Message = "Success!";

            return View();

        }


        public ActionResult EditProduct(int id)
        {

            return View(_products.GetByID(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct([Bind(Include = "ProductID,Description,Price")] Product u)
        {

           
            _products.Update(u);
            _products.Save();
            return View();

        }


        public ActionResult DeleteProduct(int id)
        {

            _products.Delete(_products.GetByID(id));
            _products.Save();
            return View("Index");
        }




    }
}