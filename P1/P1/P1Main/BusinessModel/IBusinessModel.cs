using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P1DbContext.Models;


namespace BusinessLayer
{
    public interface IBusinessModel
    {

        public bool Login(string inputUsername, string inputPassword);
        public Customer GetCurrentUser();
        public Location GetLocation(int locationId);
        public List<Location> GetLocationsList();

        public List<InventoryProduct> GetLocationProductList(int locationId);

        public Dictionary<int, int> AddToCart(Dictionary<int, int> userCart, int productId, int numAdded);

        public Dictionary<Product, int> ConvertDict(Dictionary<int, int> userCart);
    }
}
