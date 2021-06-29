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

        public void CreateAccount(Customer newUser)
        {
            context.Add(newUser);     // add the new object to the database

            context.SaveChanges();      // save and update changes
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

        public Dictionary<int, int> AddToCart(Dictionary<int, int> userCart, int productId, int numAdded)
        {
            

            if (numAdded == 0) return userCart;

            if (userCart.ContainsKey(productId))
            {
                userCart[productId] += numAdded;
            }
            else
            {
                userCart.Add(productId, numAdded);
            }


            return userCart;

        }


        public Dictionary<Product, int> ConvertDict(Dictionary<int, int> userCart)
        {
            Dictionary<Product, int> newCart = new Dictionary<Product, int>();

            foreach(var item in userCart)
            {
                Product getItem = context.Products.Where(x => x.ProductId == item.Key).FirstOrDefault();

                newCart.Add(getItem, item.Value);
            }

            return newCart;

        }

        public decimal GetCartTotal(Dictionary<Product, int> cart)
        {
            decimal sum = 0;

            foreach (var obj in cart)
            {
                sum += (obj.Key.Price * obj.Value);
            }

            return sum;
        }

    }
}
