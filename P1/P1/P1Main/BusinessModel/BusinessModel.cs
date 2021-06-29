using System;
using P1DbContext.Models;
using System.Linq;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class BusinessModel : IBusinessModel
    {
        private Customer currentUser;// { get; set; }// = new Customer();
        private Location currentLocation;// { get; set; }// = new Location();

        public P1DbClass context;

        public BusinessModel(P1DbClass context)
        {
            this.context = context;
        }

        public bool Login(string inputUsername, string inputPassword)
        {

            Customer loginUser;
            //using (P1DbClass context = new P1DbClass())
            //{
            loginUser = context.Customers.Where(x => x.UserName == inputUsername && x.Password == inputPassword).FirstOrDefault();
            //}


            if (loginUser == null)
            {
                return false;
            }
            else
            {
                currentUser = loginUser;
                return true;
            }
        }

        public Customer GetCurrentUser()
        {
            return currentUser;
        }

        public Location GetLocation(int locationId)
        {
            currentLocation = context.Locations.Where(x => x.LocationId == locationId).FirstOrDefault();
            return currentLocation;
        }

        public List<Location> GetLocationsList()
        {
            var locList = context.Locations.ToList();
            return locList;
        }

        public List<InventoryProduct> GetLocationProductList(int locationId)
        {
            //var prodList = context.Products.ToList();


            var joinResults = context.Inventories.Join(
                context.Products,
                invent => invent.ProductId,
                prod => prod.ProductId,
                (invent, prod) => new InventoryProduct(
                    prod.ProductId,
                    prod.ProductName,
                    prod.Price,
                    prod.Description,
                    prod.Category,
                    invent.LocationId,
                    invent.NumberProducts)
            ).AsEnumerable();

            List<InventoryProduct> productList = joinResults.Where(x => x.LocationId == locationId).ToList();

            return productList;
        }




    }
}
