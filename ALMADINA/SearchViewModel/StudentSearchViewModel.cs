using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ALMADINA.Entity;
using System.Web.Mvc;
     

namespace ALMADINA.SearchViewModel
{
    public class StudentSearchViewModel
    {
       
        public int LevelOrClassId { get; set; }
        public int? SectionId { get; set; }
        public string RollNumber { get; set; }
        public List<SelectListItem> LevelOrClass { get; set; }
        public List<SelectListItem> Sections { get; set; }
        public List<Student> StudentList { get; set; }
        public StudentSearchViewModel()
        {
            LevelOrClass = new List<SelectListItem>();
            Sections = new List<SelectListItem>();
            StudentList = new List<Student>();

        }
    }
}