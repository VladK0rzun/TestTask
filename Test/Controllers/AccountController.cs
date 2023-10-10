using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Test.Models;

namespace Test.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Email);
                }
                if(user == null)
                {
                    using (UserContext db = new UserContext())
                    {
                        db.Users.Add(new User
                        {
                            Email = model.Email,
                            Password = model.Password,
                            Age = model.Age,
                            FullName = model.FullName,
                            Phone = model.Phone,
                            RegionalCenter = model.RegionalCenter
                        });
                        db.SaveChanges();
                        user = db.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
                    }
                    if(user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Users", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Такого користувача не існує");
                    }
                }
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Email);
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Users", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Такого користувача не існує");
                }
            }
            return View(model);
        }
        
    }
}