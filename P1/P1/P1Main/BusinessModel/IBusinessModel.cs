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
        public List<Location> GetLocationsList();

        public Location GetLocation(int locationId);
    }
}
