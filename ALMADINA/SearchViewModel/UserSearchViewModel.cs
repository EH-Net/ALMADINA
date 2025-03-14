using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ALMADINA.Entity;
using System.Web.Mvc;

namespace ALMADINA.SearchViewModel
{
    public class UserSearchViewModel
    {
        public int UserTypeId { get; set; }
        public List<SelectListItem> UserTypes { get; set; }
        public List<User> UserList { get; set; }

        public UserSearchViewModel()
        {
            UserTypes = new List<SelectListItem>();
            UserList = new List<User>();

        }
    }
}