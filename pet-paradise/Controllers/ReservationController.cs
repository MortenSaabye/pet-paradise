using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pet_paradise.Models;
using pet_paradise.Infrastructure;

namespace pet_paradise.Content.Controllers
{
    public class ReservationController : Controller
    {
        public Repository repository = new Repository();
        //Lav liste af customers til dropdown
        private List<SelectListItem> customers = new List<SelectListItem>();

        public List<SelectListItem> makeCustomerList()
        {
            customers.Clear();
            foreach (Customer customer in repository.Customers)
            {
                customers.Add(new SelectListItem
                {
                    Text = customer.Firstname + " " + customer.Lastname,
                    Value = customer.CustomerID.ToString()
                });
            }
            return customers;
        }
        //Lav liste af species til dropdown
        private List<SelectListItem> species = new List<SelectListItem>();

        public List<SelectListItem> makeSpeciesList()
        {
            species.Clear();
            foreach (KeyValuePair<string, int> kvp in repository.Prices)
            {
                species.Add(new SelectListItem
                {
                    Text = kvp.Key,
                    Value = kvp.Key
                });
            }
            return species;
        }

        //Lav en liste af employees til dropdown
        private List<SelectListItem> employees = new List<SelectListItem>();

        public List<SelectListItem> makeEmployeeList()
        {
            employees.Clear();
            foreach (Employee employee in repository.Employees)
            {
                employees.Add(new SelectListItem
                {
                    Text = employee.Firstname + " " + employee.Lastname,
                    Value = employee.EmployeeID.ToString()
                });
            }
            return employees;
        }


        // GET: Reservation
        public ActionResult Index()
        {  
            if(Session["repository"] == null)
            {
                Session["repository"] = repository;
            } else
            {
                repository = (Repository)Session["repository"];
            }
            ViewBag.Customers = makeCustomerList();
            ViewBag.Species = makeSpeciesList();
            ViewBag.Employees = makeEmployeeList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (Session["repository"] == null)
                {
                    Session["repository"] = repository;
                }
                else
                {
                    repository = (Repository)Session["repository"];
                }
                customer.CustomerID = repository.Customers.Count + 1;
                repository.Customers.Add(customer);

                ViewBag.Customers = makeCustomerList();
                ViewBag.Species = makeSpeciesList();
                ViewBag.Employees = makeEmployeeList();
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateReservation(Reservation reservation, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                if (Session["repository"] == null)
                {
                    Session["repository"] = repository;
                }
                else
                {
                    repository = (Repository)Session["repository"];
                }
                int EmployeeID = Convert.ToInt32(form["Employees"]);
                string specie = form["Species"];

                reservation.Specie = specie;
                int ReservationID = repository.Reservations.Count + 1;

                reservation.ReservationID = ReservationID;

                // læs fra customer drop down
                int CustomerID = Convert.ToInt32(form["Customers"]);
                // find det customer object som matcher fra Repository.Customers
                Customer c = repository.Customers.ElementAt(CustomerID - 1);
                // reservation.Customer = repository.Customers.ElementAt(0) sæt til det customer object I finder
                reservation.Customer = c; //den customer I finder udfra customerID

                Employee e = repository.Employees.ElementAt(EmployeeID - 1);
                reservation.Employee = e;


                repository.Reservations.Add(reservation);
                return View(reservation);
            }
            return RedirectToAction("Index");
        }
    }
}