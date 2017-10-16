using Contracts;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {

        //IRepositoryBase<User> _users;
        UserRepositoryBase<User> _userss;

        //Constructor
        public UserController(UserRepositoryBase<User> userss)
        {
            
            _userss = userss;
        }

        // GET: Administration
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Lists products
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            // get all products and pass to view
            if( _userss.Login(u)!= null)
                return View("after");
            else
                return View();
        }

     
    }
}