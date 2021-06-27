using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P1DbContext.Models;
using P1Mvc.Models;
using BusinessLayer;

namespace P1Mvc.Controllers
{
    public class AccountController : Controller
    {

        //injecting buissness model?
        private IBusinessModel BusinessModel;

        public AccountController(IBusinessModel BusinessModel)
        {
            this.BusinessModel = BusinessModel;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer loginUser) // need to do something with sessions here?
        {
            if (ModelState.IsValid)
            {
                using (P1DbClass context = new P1DbClass())
                {
                    var obj = context.Customers.Where(x => x.Username.Equals(objUser.Username) && x.Password.Equals(objUser.Password)).FirstOrDefault();
                    return View(obj);
                }
            }
            return NotFound();
        }
        */
    }
}
