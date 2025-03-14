using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALMADINA.Entity
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}