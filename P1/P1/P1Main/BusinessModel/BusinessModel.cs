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

        public List<Order> GetOrderList()
        {
            var orderList = context.Orders.ToList();
            return orderList;
        }

        public List<Order> GetOrderList(int locationId)
        {
            var orderList = context.Orders.Where(x => x.LocationId == locationId).ToList();
            return orderList;
        }

        public List<Order> GetCustomerOrderList(int customerId)
        {
            var orderList = context.Orders.Where(x => x.CustomerId == customerId).ToList();
            return orderList;
        }


        public List<Customer> GetCustomerList(string fName = "", string lName = "")
        {
            var customerList = context.Customers.Where(x => x.FirstName.Contains(fName) && x.LastName.Contains(lName)).ToList();

            return customerList;
        }

        
        public List<OrderedProduct> GetOrderedProductList(int selectedOrderId)
        {
            var orderedProductList = context.OrderedProducts.Where(x => x.OrderId == selectedOrderId).ToList();

            return orderedProductList;
        }


        public List<string> GetCategoryList(int locationId)
        {
            var joinResults = context.Inventories.Join(
                context.Products,
                invent => invent.ProductId,
                prod => prod.ProductId,
                (invent, prod) => new
                {
                    ProductLocationId = invent.LocationId,
                    ProductCategory = prod.Category
                }

            );

            var categoryList = joinResults.Where(x => x.ProductLocationId == locationId).Distinct().ToList();

            List<string> categoryStringList = new List<string>();

            foreach(var obj in categoryList)
            {
                categoryStringList.Add(obj.ProductCategory);
            }


            return categoryStringList;
        }

        public List<InventoryProduct> GetLocationProductList(int locationId)
        {


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

        public List<InventoryProduct> GetLocationProductList(int locationId, string GetLocationProductList)
        {

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

            List<InventoryProduct> productList = joinResults.Where(x => x.LocationId == locationId && x.Category == GetLocationProductList).ToList();

            return productList;
        }

        public Order GetOrderDetails(int selectedOrderId)
        {
            var order = context.Orders.Where(x => x.OrderId == selectedOrderId).FirstOrDefault();
            return order;
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


        public Order Checkout(Dictionary<Product, int> cart, int customerId, int locationId)
        {
            Order thisOrder = new Order();
            thisOrder.OrderTime = DateTime.Now;
            thisOrder.CustomerId = customerId;
            thisOrder.LocationId = locationId;

            try
            {
                // Add the new order object to the Database
                context.Add(thisOrder);
                context.SaveChanges();
            }
            catch{};


            int newOrderId = context.Orders.Max(x => x.OrderId);
            Order newOrder = context.Orders.Where(x => x.OrderId == newOrderId).FirstOrDefault();


            foreach (var item in cart)
            {
                foreach (var obj in context.Inventories)
                {
                    if (obj.LocationId == locationId && obj.ProductId == item.Key.ProductId)
                    {
                        obj.NumberProducts -= item.Value;
                    }
                }
                // Add an ordered product object for each product in the shopping cart
                var newOrderedProduct = new OrderedProduct();
                newOrderedProduct.OrderId = newOrder.OrderId;
                newOrderedProduct.ProductId = item.Key.ProductId;
                newOrderedProduct.NumberOrdered = item.Value;
                context.Add(newOrderedProduct);
            }
            // Save Database Changes and clear user's shopping cart
            try
            {
                context.SaveChanges();
            }
            catch {};

            return newOrder;
        }

        
    }
}
