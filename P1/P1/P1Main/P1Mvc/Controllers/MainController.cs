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

            // Set to empty cart here?

            return View();
        }

        public IActionResult ShopMenu()
        {

            return View();
        }

        

        public IActionResult ReturnHome()
        {

            // Empty Shopping Cart              TODO
            return RedirectToAction("HomePage");
        }


        public ActionResult ChangeLocations()
        {
            return View(_BusinessModel.GetLocationsList());
        }

        public ActionResult BrowseProducts()                // add category filtering
        {
            Location userLocation = JsonConvert.DeserializeObject<Location>(HttpContext.Session.GetString("CurrentSessionLocation"));
            return View(_BusinessModel.GetLocationProductList(userLocation.LocationId));
        }


        public ActionResult Details(string selectedProductString)
        {
            InventoryProduct selectedProduct = JsonConvert.DeserializeObject<InventoryProduct>(selectedProductString);

            ViewBag.selectedProduct = selectedProduct;
            return View();
        }

        public ActionResult AddToCart(int? productId, int? quantity)
        {

            ViewBag.productId = (int)productId;
            ViewBag.numadded = (int)quantity;
            return View();
        }

        //public ActionResult DisplayCart()
        //{
        //    return View();
        //}

        //public ActionResult Checkout()
        //{
        //    return View();
        //}


    } // End Class
} // End Name