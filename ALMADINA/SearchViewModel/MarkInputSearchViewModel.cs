using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALMADINA.Entity;

namespace ALMADINA.SearchViewModel
{
    public class MarkInputSearchViewModel
    {
        public int LevelOrClassId { get; set; }
        public int SectionId { get; set; }
        public int GroupId { get; set; }
        public int ExamId { get; set; }
        public int SubjectId { get; set; }
        public string RollNumber { get; set; }
        public List<SelectListItem> LevelOrClass { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Sections { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Groups { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Exams { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Subjects { get; set; } = new List<SelectListItem>();      
        public List<Student> StudentList { get; set; } = new List<Student>();
        public List<Exam> ExamTypeList { get; set; } = new List<Exam>();
        public List<Subject> SubjectTypeList { get; set; } = new List<Subject>();
    }
}