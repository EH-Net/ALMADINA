using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ALMADINA.Data;
using ALMADINA.Entity;
using ALMADINA.SearchViewModel;

namespace ALMADINA.Controllers
{
    public class FeesRegisterController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: FeesRegister
        public ActionResult Index()
        {
            var feesRegisters = db.FeesRegisters.Include(f => f.FeeType).Include(f => f.LevelOrClass).Include(f => f.Section).Include(f => f.Student).Include(f => f.User);
            return View(feesRegisters.ToList());
        }

        // GET: FeesRegister/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeesRegister feesRegister = db.FeesRegisters.Find(id);
            if (feesRegister == null)
            {
                return HttpNotFound();
            }
            return View(feesRegister);
        }

        // GET: FeesRegister/Create
        public ActionResult Create()
        {
            ViewBag.FeeTypeId = new SelectList(db.FeeTypes, "Id", "FeeTypeName");
            ViewBag.LevelOrClassId = new SelectList(db.LevelOrClasses, "Id", "LevelOrClassName");
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "SectionName");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudnetName");
            ViewBag.UserId = new SelectList(db.Useres, "Id", "FullName");
            return View();
        }

        // POST: FeesRegister/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,StudentName,FatehrsName,MotehrsName,LevelOrClassId,SectionId,RollNo,FeeTypeId,FeeAmount,FeeAlreadyRecived,DueAmount,PaidAmount,Cash,BKash,Nagad,PayandPaid,Reference,CreateAt,UpdateAt,Status,UserId")] FeesRegister feesRegister)
        {
            if (ModelState.IsValid)
            {
                db.FeesRegisters.Add(feesRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FeeTypeId = new SelectList(db.FeeTypes, "Id", "FeeTypeName", feesRegister.FeeTypeId);
            ViewBag.LevelOrClassId = new SelectList(db.LevelOrClasses, "Id", "LevelOrClassName", feesRegister.LevelOrClassId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "SectionName", feesRegister.SectionId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudnetName", feesRegister.StudentId);
            ViewBag.UserId = new SelectList(db.Useres, "Id", "FullName", feesRegister.UserId);
            return View(feesRegister);
        }

        // GET: FeesRegister/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeesRegister feesRegister = db.FeesRegisters.Find(id);
            if (feesRegister == null)
            {
                return HttpNotFound();
            }
            ViewBag.FeeTypeId = new SelectList(db.FeeTypes, "Id", "FeeTypeName", feesRegister.FeeTypeId);
            ViewBag.LevelOrClassId = new SelectList(db.LevelOrClasses, "Id", "LevelOrClassName", feesRegister.LevelOrClassId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "SectionName", feesRegister.SectionId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudnetName", feesRegister.StudentId);
            ViewBag.UserId = new SelectList(db.Useres, "Id", "FullName", feesRegister.UserId);
            return View(feesRegister);
        }

        // POST: FeesRegister/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,StudentName,FatehrsName,MotehrsName,LevelOrClassId,SectionId,RollNo,FeeTypeId,FeeAmount,FeeAlreadyRecived,DueAmount,PaidAmount,Cash,BKash,Nagad,PayandPaid,Reference,CreateAt,UpdateAt,Status,UserId")] FeesRegister feesRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feesRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FeeTypeId = new SelectList(db.FeeTypes, "Id", "FeeTypeName", feesRegister.FeeTypeId);
            ViewBag.LevelOrClassId = new SelectList(db.LevelOrClasses, "Id", "LevelOrClassName", feesRegister.LevelOrClassId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "SectionName", feesRegister.SectionId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudnetName", feesRegister.StudentId);
            ViewBag.UserId = new SelectList(db.Useres, "Id", "FullName", feesRegister.UserId);
            return View(feesRegister);
        }

        // GET: FeesRegister/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeesRegister feesRegister = db.FeesRegisters.Find(id);
            if (feesRegister == null)
            {
                return HttpNotFound();
            }
            return View(feesRegister);
        }

        // POST: FeesRegister/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeesRegister feesRegister = db.FeesRegisters.Find(id);
            db.FeesRegisters.Remove(feesRegister);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DailyFeeCollection()
        {

            var dailyfeeSVM = new DailyFeesCollectionSearchViewModel();

            dailyfeeSVM.LevelOrClass = db.LevelOrClasses.AsEnumerable().Select(n => new SelectListItem
            {
                Text = n.LevelOrClassName,
                Value = n.Id.ToString()
            }).ToList();
            dailyfeeSVM.Sections = db.Sections.AsEnumerable().Select(n => new SelectListItem
            {
                Text = n.SectionName,
                Value = n.Id.ToString()
            }).ToList();

            return View(dailyfeeSVM);

        }

        [HttpPost]
        public ActionResult DailyFeeCollection(DailyFeesCollectionSearchViewModel dailyFSVM)
        {

            dailyFSVM.LevelOrClass = db.LevelOrClasses.AsEnumerable().Select(n => new SelectListItem
            {
                Text = n.LevelOrClassName,
                Value = n.Id.ToString()
            }).ToList();
            dailyFSVM.Sections = db.Sections.AsEnumerable().Select(n => new SelectListItem
            {
                Text = n.SectionName,
                Value = n.Id.ToString()
            }).ToList();
            dailyFSVM.StudentList = db.Students.Where(s => s.LevelOrClassId == dailyFSVM.LevelOrClassId && s.SectionId == dailyFSVM.SectionId && s.RollNo == dailyFSVM.RollNumber).ToList();
            dailyFSVM.FeeTypeList = db.FeeTypes.Where(i => i.LevelOrClassId == dailyFSVM.LevelOrClassId && i.SectionId == dailyFSVM.SectionId).ToList();
            dailyFSVM.FeeRegisterList = db.FeesRegisters.Where(i => i.LevelOrClassId == dailyFSVM.LevelOrClassId && i.SectionId == dailyFSVM.SectionId && i.RollNo == dailyFSVM.RollNumber).ToList();

            return View(dailyFSVM);
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
