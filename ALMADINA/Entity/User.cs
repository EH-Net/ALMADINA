using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALMADINA.Entity
{
    public class User
    {
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }       
        public bool IsActive { get; set; }

        public virtual UserType UserType { get; set; }
    }
}