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
        private IBusinessModel _BusinessModel;

        public AccountController(IBusinessModel BusinessModel)
        {
            this._BusinessModel = BusinessModel;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginLandingPage(Customer loginUser) // need to do something with sessions here?
        {
            bool loginStatus = _BusinessModel.Login(loginUser.UserName, loginUser.Password);
            if(loginStatus)
            {
                return View(_BusinessModel.GetCurrentUser());
                
            }
            else
            {
                return NotFound();
            }
            //if (ModelState.IsValid)
            //{
            //    using (P1DbClass context = new P1DbClass())
            //    {
            //        var obj = context.Customers.Where(x => x.Username.Equals(objUser.Username) && x.Password.Equals(objUser.Password)).FirstOrDefault();
            //        return View(obj);
            //    }
            //}
            //return NotFound();
        }
        
    }
}
