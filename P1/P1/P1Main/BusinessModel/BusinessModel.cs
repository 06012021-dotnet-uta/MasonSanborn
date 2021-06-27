using System;
using P1DbContext.Models;
using System.Linq;


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
            using (P1DbClass context = new P1DbClass())
            {
                loginUser = context.Customers.Where(x => x.UserName == inputUsername && x.Password == inputPassword).FirstOrDefault();
            }


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

    }
}
