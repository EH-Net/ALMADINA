using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALMADINA.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string StudnetName { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [Display(Name = "Class")]
        public int? LevelOrClassId { get; set; }

        [Display(Name = "Section")]
        public int? SectionId { get; set; }
        public string RollNo { get; set; }
        public int GenderId { get; set; }
        [Display(Name = "Regligion")]
        public int ReligionId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [Display(Name = "User")]
        public int? UserId { get; set; }
        public string PhotoUrl { get; set; }

        [Display(Name = "Profile Photo")]
        [NotMapped]
        public HttpPostedFileBase PhotoUpload { get; set; }




        public virtual LevelOrClass LevelOrClass { get; set; }
        public virtual Section Section { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual User User { get; set; }
        public virtual Religion Religion { get; set; }
    }
}