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

namespace ALMADINA.Controllers
{
    public class LevelOrClassController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: LevelOrClass
        public ActionResult Index()
        {
            return View(db.LevelOrClasses.ToList());
        }

        // GET: LevelOrClass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelOrClass levelOrClass = db.LevelOrClasses.Find(id);
            if (levelOrClass == null)
            {
                return HttpNotFound();
            }
            return View(levelOrClass);
        }

        // GET: LevelOrClass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LevelOrClass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LevelOrClassName")] LevelOrClass levelOrClass)
        {
            if (ModelState.IsValid)
            {
                db.LevelOrClasses.Add(levelOrClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(levelOrClass);
        }

        // GET: LevelOrClass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelOrClass levelOrClass = db.LevelOrClasses.Find(id);
            if (levelOrClass == null)
            {
                return HttpNotFound();
            }
            return View(levelOrClass);
        }

        // POST: LevelOrClass/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LevelOrClassName")] LevelOrClass levelOrClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(levelOrClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(levelOrClass);
        }

        // GET: LevelOrClass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelOrClass levelOrClass = db.LevelOrClasses.Find(id);
            if (levelOrClass == null)
            {
                return HttpNotFound();
            }
            return View(levelOrClass);
        }

        // POST: LevelOrClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LevelOrClass levelOrClass = db.LevelOrClasses.Find(id);
            db.LevelOrClasses.Remove(levelOrClass);
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
