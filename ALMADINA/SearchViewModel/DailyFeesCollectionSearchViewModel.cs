using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ALMADINA.Entity;
using System.Web.Mvc;

namespace ALMADINA.SearchViewModel
{
    public class DailyFeesCollectionSearchViewModel
    {
        public int LevelOrClassId { get; set; }
        public int SectionId { get; set; }
        public string RollNumber { get; set; }
        public List<SelectListItem> LevelOrClass { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Sections { get; set; } = new List<SelectListItem>();
        public List<Student> StudentList { get; set; } = new List<Student>();
        public List<FeeType> FeeTypeList { get; set; } = new List<FeeType>();
        public List<FeesRegister> FeeRegisterList { get; set; } = new List<FeesRegister>();
    }
}