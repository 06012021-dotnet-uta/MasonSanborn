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


    }
}
