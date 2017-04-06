using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pet_paradise.Infrastructure;

namespace pet_paradise.Content.Controllers
{
    public class ToolsController : Controller
    {
        // GET: Tools
        [ChildActionOnly]
        public ActionResult Navigation()
        {
            string[] navItems = { "Services", "Reservation", "Contact" }; 
            return View("_Navigation", navItems);
        }

        [ChildActionOnly]
        public ActionResult PriceList()
        {
            Repository repository = new Repository();
            Dictionary<string, int> prices = repository.Prices;
            return View("_PriceList", prices);
        }

        [ChildActionOnly]
        public ActionResult Hours()
        {
            Repository repository = new Repository();
            Dictionary<string, string> hours = repository.Hours;
            return View("_OpeningHours", hours);
        }
    }
}