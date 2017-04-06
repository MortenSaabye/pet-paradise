using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pet_paradise.Models;
using pet_paradise.Infrastructure;

namespace pet_paradise.Areas.Admin.Controllers
{
    public class InvoicesController : Controller
    {
        private List<SelectListItem> customers = new List<SelectListItem>();
        Repository repository = new Repository();
        // GET: Invoices
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
            foreach (Customer customer in repository.Customers)
            {
                customers.Add(new SelectListItem
                {
                    Text = customer.Firstname + " " + customer.Lastname,
                    Value = customer.CustomerID.ToString()
                });
            }
            ViewBag.Customers = customers;
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (Session["repository"] == null)
            {
                Session["repository"] = repository;
            }
            else
            {
                repository = (Repository)Session["repository"];
            }
            string invoicesFor = form["Customers"];
            foreach (Customer customer in repository.Customers)
            {
                if (invoicesFor == customer.CustomerID.ToString())
                {
                    customers.Add(new SelectListItem
                    {
                        Text = customer.Firstname + " " + customer.Lastname,
                        Value = customer.CustomerID.ToString(),
                        Selected = true
                    });
                }
                else
                {
                    customers.Add(new SelectListItem
                    {
                        Text = customer.Firstname + " " + customer.Lastname,
                        Value = customer.CustomerID.ToString()
                    });
                }
            }
            List<Reservation> reservations = new List<Reservation>();

            foreach (Reservation reservation in repository.Reservations)
            {
                if(reservation.Customer.CustomerID.ToString() == invoicesFor)
                {
                    reservations.Add(reservation);
                }
            }
            ViewBag.Reservations = reservations;
            ViewBag.Customers = customers;
            ViewBag.Repository = repository;
            return View();
        }
    }
    
}