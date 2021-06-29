﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P1DbContext.Models;
using P1Mvc.Models;
using BusinessLayer;
// added to add sessions
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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
        public ActionResult LoginLandingPage(Customer loginUser)
        {
            bool loginStatus = _BusinessModel.Login(loginUser.UserName, loginUser.Password);
            if(loginStatus)
            {

                var currentUser = _BusinessModel.GetCurrentUser();
                ViewBag.currentUser = currentUser;
                Dictionary<int, int> userCart = new Dictionary<int, int>();
                // set the value into a session key
                HttpContext.Session.SetString("CurrentSessionUser", JsonConvert.SerializeObject(currentUser));
                HttpContext.Session.SetString("CurrentSessionUserCart", JsonConvert.SerializeObject(userCart));


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
        public ActionResult LocationSelected(int? storeLocationId) // need to do something with sessions here?
        {

            Location currentLoc = _BusinessModel.GetLocation((int)storeLocationId);


            HttpContext.Session.SetString("CurrentSessionLocation", JsonConvert.SerializeObject(currentLoc));

            return RedirectToAction("HomePage", "Main");
        }



    }
}
