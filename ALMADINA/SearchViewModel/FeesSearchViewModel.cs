using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALMADINA.Entity;

namespace ALMADINA.SearchViewModel
{
    public class FeesSearchViewModel
    {
       
        public int LevelOrClassId { get; set; }
        public int? SectionId { get; set; }       
        public List<SelectListItem> LevelOrClass { get; set; }
        public List<SelectListItem> Sections { get; set; }
        public List<FeeType> FeeList { get; set; }
      
        public FeesSearchViewModel()
        {
            LevelOrClass = new List<SelectListItem>();
            Sections = new List<SelectListItem>();
            FeeList = new List<FeeType>();           

        }
    }
}