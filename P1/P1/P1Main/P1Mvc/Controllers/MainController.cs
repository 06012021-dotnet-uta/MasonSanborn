using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using P1DbContext.Models;

namespace P1Mvc.Controllers
{
    public class MainController : Controller
    {

        //injecting buissness model?
        public IBusinessModel _BusinessModel;

        public MainController(IBusinessModel BusinessModel)
        {
            this._BusinessModel = BusinessModel;
        }


        public IActionResult HomePage(/*Location sendLocation, Customer sendUser*/)
        {
            ViewBag.currentLocation = TempData["AccountCurrentLocation"];
            ViewBag.currentUser = TempData["AccountCurrentUser"];

            //ViewBag.currentLocation = TempData.ContainsKey("AccountCurrentLocation");
            //ViewBag.currentUser = TempData.ContainsKey("AccountCurrentUser");

            //ViewBag.currentLocation = TempData.First();
            //ViewBag.currentUser = TempData.Last();

            //ViewBag.currentLocation = sendLocation;
            //ViewBag.currentUser = sendUser;


            if (ViewBag.currentUser == null)
            {
                Customer currentUser = new Customer();
                currentUser.FirstName = "ree";
                currentUser.LastName = "reeeeee";


                ViewBag.currentUser = currentUser;
            }

            return View();
        }






    }
}