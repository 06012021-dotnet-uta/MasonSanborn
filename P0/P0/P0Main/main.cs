using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using P0DbContext.Models;
using CurrentUserNamespace;



namespace P0Main
{
    class main
    {
        static void Main(string[] args)
        {
            // Load Database
            P0DbClass context = new P0DbClass();


            // Create object for current user
            CurrentUser user = new CurrentUser();

            // Create new view controller
            BuissnessModel currentProgram = new BuissnessModel(user, context);


            //user.shoppingCart.Add();


            do
            {
                Login:
                // Program info / user login / user register
                currentProgram.Startup();

                currentProgram.ChooseLocation();

                //currentProgram.RunProgram();
                
                while (true)
                {
                    int displayOptionsChoice = currentProgram.MainMenuOptions();
                    switch (displayOptionsChoice)
                    {
                        case 1: // Shop
                            currentProgram.ShopAtLocation();
                            // ViewController.Shopping();
                            // show available products at current location
                            // show categories then breakup into items?
                            // offer recomendations to user?

                            // - Allow user to choose from avialable products 
                            // move through pages of products?

                            // - store chosen products and quanitity in shopping cart


                            // modify cart option?

                            // allow to checkout

                            // get sum of price and display to user
                            // remove items from stores inventory after sold and update database
                            continue;
                        case 2: // Change Locations
                            currentProgram.ChooseLocation();
                            break;
                        case 3: // logout
                            // do logout handling?
                            goto Login;

                    }

                }


            } while (true);

            #region
            //foreach (var prod in context.Products)
            //{
            //    //var prodName  = prod.ProductName;
            //    //var prodPrice = prod.Price;
            //    Console.WriteLine($"Products: Name: {prod.ProductName}\t Price: {prod.Price}");
            //}
            #endregion
            #region new customer example
            ////var newCustomer = new Customer();       // create new object from database types

            ////// set object attributes
            ////newCustomer.FirstName = "Luke";
            ////newCustomer.LastName = "Scott";
            ////newCustomer.UserName = "sc98";
            ////newCustomer.Password = "xx113";

            ////context.Add(newCustomer);     // add the new object to the database

            ////context.SaveChanges();      // save and update changes
            #endregion
            #region
            //var results = context.Products.Where(x => x.ProductName == "Chicken");

            //foreach (var result in results)
            //{
            //    //var prodName  = prod.ProductName;
            //    //var prodPrice = prod.Price;
            //    Console.WriteLine($"Products: Name: {result.ProductName}");
            //}
            #endregion


        }
    }
}
