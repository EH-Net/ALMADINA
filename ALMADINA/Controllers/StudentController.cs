using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ALMADINA.Data;
using ALMADINA.Entity;
using ALMADINA.SearchViewModel;
using Microsoft.Ajax.Utilities;


namespace ALMADINA.Controllers
{
    public class StudentController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Student
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            // create StudentSearchViewModel object or instance
            var studentSVM = new StudentSearchViewModel();

            studentSVM.LevelOrClass = db.LevelOrClasses.AsEnumerable().Select(n => new SelectListItem
            {
                Text = n.LevelOrClassName,
                Value = n.Id.ToString()
            }).ToList();
            studentSVM.Sections = db.Sections.AsEnumerable().Select(n => new SelectListItem
            {
                Text = n.SectionName,
                Value = n.Id.ToString()
            }).ToList();

            return View(studentSVM);
        }

        [HttpPost]
        public ActionResult Index(StudentSearchViewModel filter)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            filter.LevelOrClass = db.LevelOrClasses.AsEnumerable().Select(n => new SelectListItem
            {
                Text = n.LevelOrClassName,
                Value = n.Id.ToString()
            }).ToList();
            filter.Sections = db.Sections.AsEnumerable().Select(n => new SelectListItem
            {
                Text = n.SectionName,
                Value = n.Id.ToString()
            }).ToList();

            if (!string.IsNullOrEmpty(filter.LevelOrClassId.ToString()) && string.IsNullOrEmpty(filter.SectionId.ToString()) && string.IsNullOrEmpty(filter.RollNumber))
            {
                filter.StudentList = db.Students.Where(i => i.LevelOrClassId == filter.LevelOrClassId).ToList();
            }
            else if (!string.IsNullOrEmpty(filter.LevelOrClassId.ToString()) && !string.IsNullOrEmpty(filter.SectionId.ToString()) && string.IsNullOrEmpty(filter.RollNumber))
            {
                filter.StudentList = db.Students.Where(i => i.LevelOrClassId == filter.LevelOrClassId && i.SectionId == filter.SectionId).ToList();
            }
            else if (!string.IsNullOrEmpty(filter.LevelOrClassId.ToString()) && !string.IsNullOrEmpty(filter.SectionId.ToString()) && !string.IsNullOrEmpty(filter.RollNumber))
            {
                filter.StudentList = db.Students.Where(i => i.LevelOrClassId == filter.LevelOrClassId && i.SectionId == filter.SectionId && i.RollNo == filter.RollNumber).ToList();
            }
            else
            {
                return HttpNotFound();
            }


            return View(filter);
        }


        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "GenderName");
            ViewBag.LevelOrClassId = new SelectList(db.LevelOrClasses, "Id", "LevelOrClassName");
            ViewBag.ReligionId = new SelectList(db.Religions, "Id", "ReligionName");
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "SectionName");
            ViewBag.UserId = new SelectList(db.Useres, "Id", "FullName");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student, HttpPostedFileBase PhotoUpload)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }

            var userId = Convert.ToInt32(Convert.ToString(Session["Id"]));
            student.UserId = userId;
            if (ModelState.IsValid)
            {
                // Handle the file upload
                if (PhotoUpload != null && PhotoUpload.ContentLength > 0)
                {
                    var ext = Path.GetExtension(PhotoUpload.FileName);
                    var size = PhotoUpload.ContentLength;
                    if (ext.Equals(".png") || ext.Equals(".jpg") || ext.Equals(".jpeg"))
                    {
                        if (size <= 1000000)
                        {
                            PhotoUpload.SaveAs(HttpContext.Server.MapPath("~/Images/") + PhotoUpload.FileName);
                            student.PhotoUrl = PhotoUpload.FileName;
                            db.Students.Add(student);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["Size_Error"] = "Image must be less than 1 MB.";
                        }
                    }
                    else
                    {
                        TempData["Ext_Error"] = "Only PNG,JPG ,JPEG Images are allowed";
                    }

                }

                ViewBag.GenderId = new SelectList(db.Genders, "Id", "GenderName", student.GenderId);
                ViewBag.ReligionId = new SelectList(db.Religions, "Id", "ReligionName", student.ReligionId);
                ViewBag.SectionId = new SelectList(db.Sections, "Id", "SectionName", student.SectionId);
                ViewBag.ShreniOrClassId = new SelectList(db.LevelOrClasses, "Id", "ShreniOrClassName", student.LevelOrClassId);
                ViewBag.UserId = new SelectList(db.Useres, "Id", "FullName", student.UserId);
                return View(student);
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "GenderName", student.GenderId);
            ViewBag.LevelOrClassId = new SelectList(db.LevelOrClasses, "Id", "LevelOrClassName", student.LevelOrClassId);
            ViewBag.ReligionId = new SelectList(db.Religions, "Id", "ReligionName", student.ReligionId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "SectionName", student.SectionId);
            ViewBag.UserId = new SelectList(db.Useres, "Id", "FullName", student.UserId);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudnetName,FathersName,MothersName,DOB,LevelOrClassId,SectionId,RollNo,GenderId,ReligionId,Phone,Address,UserId,PhotoUrl")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "GenderName", student.GenderId);
            ViewBag.LevelOrClassId = new SelectList(db.LevelOrClasses, "Id", "LevelOrClassName", student.LevelOrClassId);
            ViewBag.ReligionId = new SelectList(db.Religions, "Id", "ReligionName", student.ReligionId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "SectionName", student.SectionId);
            ViewBag.UserId = new SelectList(db.Useres, "Id", "FullName", student.UserId);
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
