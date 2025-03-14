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
    public class UserController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: User
        public ActionResult Index()
        {
            //var useres = db.Useres.Include(u => u.UserType);
            //return View(useres.ToList());
            var List = new UserSearchViewModel();

            List.UserTypes = db.UserTypes.AsEnumerable().Select(n => new SelectListItem
            {
                Text = n.UserTypeName,
                Value = n.Id.ToString()
            }).ToList();
            return View(List);
        }

        [HttpPost]
        public ActionResult Index(UserSearchViewModel userSVM)
        {
            userSVM.UserTypes = db.UserTypes.AsEnumerable().Select(n => new SelectListItem
            {
                Text = n.UserTypeName,
                Value = n.Id.ToString()
            }).ToList();


            userSVM.UserList = db.Useres.Where(u => u.UserTypeId == userSVM.UserTypeId).ToList();

            
            return View(userSVM);
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Useres.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "UserTypeName");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Useres.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "UserTypeName", user.UserTypeId);
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Useres.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "UserTypeName", user.UserTypeId);
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserTypeId,FullName,UserName,Password,Phone,Email,IsActive")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "UserTypeName", user.UserTypeId);
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Useres.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Useres.Find(id);
            db.Useres.Remove(user);
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
