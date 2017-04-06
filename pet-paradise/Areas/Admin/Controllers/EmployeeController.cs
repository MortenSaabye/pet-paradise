using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pet_paradise.Infrastructure;

namespace pet_paradise.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee
        public ActionResult Index()
        {
            Repository repository = new Repository();
            ViewBag.Employees = repository.Employees; 
            return View();
        }
    }
}