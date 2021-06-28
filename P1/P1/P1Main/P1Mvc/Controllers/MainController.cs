﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using P1DbContext.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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


        public IActionResult HomePage()
        {


            Location userLocation = JsonConvert.DeserializeObject<Location>(HttpContext.Session.GetString("CurrentSessionLocation"));
            Customer userCustomer = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString("CurrentSessionUser"));

            ViewBag.currentLocation = userLocation;
            ViewBag.currentUser = userCustomer;



            return View();
        }






    }
}