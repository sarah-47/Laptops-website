using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_3_mvc.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public String UserName { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}