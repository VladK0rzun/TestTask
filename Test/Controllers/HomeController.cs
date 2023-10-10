using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext _context = new UserContext();

        public ActionResult Users(string sort)
        {
            var users = _context.Users.AsQueryable();

            switch (sort)
            {
                case "FullName":
                    users = users.OrderBy(p => p.FullName);
                    break;
                case "Age":
                    users = users.OrderBy(p => p.Age);
                    break;
                case "RegionalCenter":
                    users = users.OrderBy(p => p.RegionalCenter);
                    break;
                default:
                    users = users.OrderBy(p => p.FullName);
                    break;
            }

            return View(users.ToList());
        }

        
    }
}