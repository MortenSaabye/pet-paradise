using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pet_paradise.Infrastructure;
using pet_paradise.Models;

namespace pet_paradise.Areas.Admin.Controllers
{
    public class PricesController : Controller
    {
        // GET: Prices
        public ActionResult Index()
        {
            Repository repository = new Repository();
            ViewBag.Repository = repository;
            return View();
        }
    }
}