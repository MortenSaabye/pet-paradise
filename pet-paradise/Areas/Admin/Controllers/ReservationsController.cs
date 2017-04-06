using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pet_paradise.Infrastructure;
using pet_paradise.Models;

namespace pet_paradise.Areas.Admin.Controllers
{
    public class ReservationsController : Controller
    {
        Repository repository = new Repository();
        // GET: Reservations
        public ActionResult Index()
        {
            if (Session["repository"] == null)
            {
                Session["repository"] = repository;
            }
            else
            {
                repository = (Repository)Session["repository"];
            }
            ViewBag.Repository = repository;
            return View();
        }   
    }
}