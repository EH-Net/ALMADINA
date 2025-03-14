using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALMADINA.Data;


namespace ALMADINA.Controllers
{
    public class HomeController : Controller
    {
        private ProjectContext db = new ProjectContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {      

            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    ViewBag.Message = "Empty fields are not allowed.";
                    return View("Login");
                }

                var user = db.Useres.SingleOrDefault(v => v.Email == email && v.Password == password);
                if (user == null)
                {
                    ViewBag.Message = "Email and Password are incorrect!";
                    return View("Login");
                }

                if (!user.IsActive)
                {
                    ViewBag.Message = "Your account is inactive.";
                    return View("Login");
                }

                // Set session values
                Session["Id"] = user.Id;
                Session["UserTypeId"] = user.UserTypeId;
                Session["FullName"] = user.FullName;
                Session["UserName"] = user.UserName;
                Session["Password"] = user.Password;
                Session["Phone"] = user.Phone;
                Session["Email"] = user.Email;                
                Session["IsActive"] = user.IsActive;

                // Redirect based on user type
                string url = string.Empty;
                switch (user.UserTypeId)
                {
                    case 1:
                        var adminDetails = db.Useres.Any(u => u.UserTypeId == user.UserTypeId);
                        url = "Index";
                        break;
                    case 2:
                        var teacherDetails = db.Useres.Any(u => u.UserTypeId == user.UserTypeId);
                        url = "Index";
                        break;
                    case 3:
                        var operatorDetails = db.Useres.Any(u => u.UserTypeId == user.UserTypeId);
                        url = operatorDetails ? "Create" : "Index";
                        break;
                    case 4:
                        var studentDetails = db.Useres.Any(u => u.UserTypeId == user.UserTypeId);
                        url = studentDetails ? "Create" : "Index";
                        break;
                    default:
                        url = "Login";
                        break;
                }
                return RedirectToAction(url);
            }
            catch (Exception)
            {
                // Log the exception (ex) here              
                ViewBag.Message = "An error occurred. Please try again.";
                return View("Login");
            }
        }


        public ActionResult Logoff()
        {
            Session.Clear();

            Session.Abandon();

            return RedirectToAction("Login", "User");
        }

    }
}