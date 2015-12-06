using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shpping_Order
{
    class Admin:User
    {
        public string AdminName { get; set; }
        public string Email { get; set; }

        public Admin(string username,string password,string adminname,string email)
            :base(username,password)
        {
            this.AdminName = adminname;
            this.Email = email;
        }

        public void Addorder()
        {
 
        }

        public void DeleteOrder()
        {

        }

        public void UpdateOrderr()
        {

        }

        public void UpdateCustomerr()
        {

        }

        public void RemoveCustomer()
        {

        }

        public void AddShop()
        {

        }

        public void RemoveShop()
        {

        }

        public void UpdateShop()
        {

        }

    }
}
