using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALMADINA.Entity
{
    public class FeeType
    {
        public int Id { get; set; }
        public int? LevelOrClassId { get; set; }
        public int? SectionId { get; set; }
        public string FeeTypeName { get; set; }
        public double FeeAmount { get; set; }        
        public DateTime LastDate { get; set; }
        public int? UserId { get; set; }       
       

        public virtual LevelOrClass LevelOrClass { get; set; }
        public virtual Section Section { get; set; }
        public virtual User User { get; set; }
    } 
}