using System;
using P1DbContext.Models;
using System.Linq;


namespace BusinessLayer
{
    public class BusinessModel : IBusinessModel
    {
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
                return true;
            }
        }

    }
}
