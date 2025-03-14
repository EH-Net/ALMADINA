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
    public class FeeTypeController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: FeeType
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var studentSVM = new FeesSearchViewModel();

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
        public ActionResult Index(FeesSearchViewModel filter)
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

            if (!string.IsNullOrEmpty(filter.LevelOrClassId.ToString()) && !string.IsNullOrEmpty(filter.SectionId.ToString()))
            {
                filter.FeeList = db.FeeTypes.Where(i => i.LevelOrClassId == filter.LevelOrClassId && i.SectionId == filter.SectionId).ToList();
            }           

            return View(filter);
        }

        // GET: FeeType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeType feeType = db.FeeTypes.Find(id);
            if (feeType == null)
            {
                return HttpNotFound();
            }
            return View(feeType);
        }

        // GET: FeeType/Create
        public ActionResult Create()
        {
            ViewBag.LevelOrClassId = new SelectList(db.LevelOrClasses, "Id", "LevelOrClassName");
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "SectionName");
            ViewBag.UserId = new SelectList(db.Useres, "Id", "FullName");
            return View();
        }

        // POST: FeeType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LevelOrClassId,SectionId,FeeTypeName,FeeAmount,LastDate,UserId")] FeeType feeType)
        {
            if (ModelState.IsValid)
            {
                db.FeeTypes.Add(feeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LevelOrClassId = new SelectList(db.LevelOrClasses, "Id", "LevelOrClassName", feeType.LevelOrClassId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "SectionName", feeType.SectionId);
            ViewBag.UserId = new SelectList(db.Useres, "Id", "FullName", feeType.UserId);
            return View(feeType);
        }

        // GET: FeeType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeType feeType = db.FeeTypes.Find(id);
            if (feeType == null)
            {
                return HttpNotFound();
            }
            ViewBag.LevelOrClassId = new SelectList(db.LevelOrClasses, "Id", "LevelOrClassName", feeType.LevelOrClassId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "SectionName", feeType.SectionId);
            ViewBag.UserId = new SelectList(db.Useres, "Id", "FullName", feeType.UserId);
            return View(feeType);
        }

        // POST: FeeType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LevelOrClassId,SectionId,FeeTypeName,FeeAmount,LastDate,UserId")] FeeType feeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LevelOrClassId = new SelectList(db.LevelOrClasses, "Id", "LevelOrClassName", feeType.LevelOrClassId);
            ViewBag.SectionId = new SelectList(db.Sections, "Id", "SectionName", feeType.SectionId);
            ViewBag.UserId = new SelectList(db.Useres, "Id", "FullName", feeType.UserId);
            return View(feeType);
        }

        // GET: FeeType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeeType feeType = db.FeeTypes.Find(id);
            if (feeType == null)
            {
                return HttpNotFound();
            }
            return View(feeType);
        }

        // POST: FeeType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeeType feeType = db.FeeTypes.Find(id);
            db.FeeTypes.Remove(feeType);
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
