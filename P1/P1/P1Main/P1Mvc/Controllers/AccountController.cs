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
        public IBusinessModel _BusinessModel;

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
                //return View(_BusinessModel.GetCurrentUser());
                //Session["currentUser"] = _BusinessModel.GetCurrentUser();
                var currentUser = _BusinessModel.GetCurrentUser();
                ViewBag.currentUser = currentUser;
                //HttpContext.Session.Set("currentUser", currentUser);
                //TempData["AccountCurrentUser"] = currentUser;
                return View(_BusinessModel.GetLocationsList());
                
            }
            else
            {
                return NotFound();
                // handle this differntly?
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LocationSelected(int locationId) // need to do something with sessions here?
        {
            //Console.WriteLine(locationId);
            var currentLoc = _BusinessModel.GetLocation(locationId);
            ViewBag.currentLocation = currentLoc;
            ViewBag.currentUser = _BusinessModel.GetCurrentUser();

            //TempData["AccountCurrentUser"] = ViewBag.currentUser;
            //TempData["AccountCurrentLocation"] = ViewBag.currentLocation;

            //var test = _BusinessModel.GetCurrentUser();

            //Console.WriteLine($"Current User: {currentLoc.LocationName} {currentLoc.LocationId}");
            //Console.WriteLine($"Current User: {test.FirstName} {test.LastName}");

            return RedirectToAction("HomePage", currentLoc);
            //return RedirectToAction("HomePage", "Main");//, new { sendLocation = ViewBag.currentUser, sendUser = ViewBag.currentLocation});   // redirect to main controller home page
        }
        

    }
}
