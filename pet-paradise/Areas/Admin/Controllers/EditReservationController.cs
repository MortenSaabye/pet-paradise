using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pet_paradise.Models;
using pet_paradise.Infrastructure;

namespace pet_paradise.Areas.Admin.Controllers
{
    public class EditReservationController : Controller
    {
        public Repository repository = new Repository();

        //Lav liste af customers til dropdown
        private List<SelectListItem> customers = new List<SelectListItem>();

        public List<SelectListItem> makeCustomerList(Reservation res)
        {
            customers.Clear();
            foreach (Customer customer in repository.Customers)
            {
                if (customer.CustomerID == res.Customer.CustomerID)
                {
                    customers.Add(new SelectListItem
                    {
                        Text = customer.Firstname + " " + customer.Lastname,
                        Value = customer.CustomerID.ToString(),
                        Selected = true
                    });
                } else
                {
                    customers.Add(new SelectListItem
                    {
                        Text = customer.Firstname + " " + customer.Lastname,
                        Value = customer.CustomerID.ToString(),
                    });
                }
            }
            return customers;
        }
        //Lav liste af species til dropdown
        private List<SelectListItem> species = new List<SelectListItem>();

        public List<SelectListItem> makeSpeciesList(Reservation res)
        {
            species.Clear();
            foreach (KeyValuePair<string, int> kvp in repository.Prices)
            {
                if (kvp.Key == res.Specie)
                {
                    species.Add(new SelectListItem
                    {
                        Text = kvp.Key,
                        Value = kvp.Key,
                        Selected = true
                    });
                }
                else
                {
                    species.Add(new SelectListItem
                    {
                        Text = kvp.Key,
                        Value = kvp.Key,
                    });
                }
            }
            return species;
        }

        //Lav en liste af employees til dropdown
        private List<SelectListItem> employees = new List<SelectListItem>();

        public List<SelectListItem> makeEmployeeList(Reservation res)
        {
            employees.Clear();
            foreach (Employee employee in repository.Employees)
            {
                if(employee.EmployeeID == res.Employee.EmployeeID)
                {
                    employees.Add(new SelectListItem
                    {
                        Text = employee.Firstname + " " + employee.Lastname,
                        Value = employee.EmployeeID.ToString(),
                        Selected = true
                    });
                } else
                {
                    employees.Add(new SelectListItem
                    {
                        Text = employee.Firstname + " " + employee.Lastname,
                        Value = employee.EmployeeID.ToString()
                    });
                }
               
            }
            return employees;
        }

        // GET: Admin/EditReservation
        public ActionResult Index(int reservationID)
        {
            if (Session["repository"] == null)
            {
                Session["repository"] = repository;
            }
            else
            {
                repository = (Repository)Session["repository"];
            }
            Reservation res = repository.Reservations.Find(x => x.ReservationID == reservationID);
            ViewBag.Customers = makeCustomerList(res);
            ViewBag.Species = makeSpeciesList(res);
            ViewBag.Employees = makeEmployeeList(res);
            //ViewBag.StartDate = res.StartDate.ToString("yyyy-MM-dd");
            //ViewBag.EndDate = res.EndDate.ToString("yyyy-MM-dd");
            return View(res);
        }
        public ActionResult EditReservation(Reservation newRes, FormCollection form)
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

            newRes.Specie = specie;


            // læs fra customer drop down
            int CustomerID = Convert.ToInt32(form["Customers"]);
            // find det customer object som matcher fra Repository.Customers
            Customer c = repository.Customers.ElementAt(CustomerID - 1);
            // reservation.Customer = repository.Customers.ElementAt(0) sæt til det customer object I finder
            newRes.Customer = c; //den customer I finder udfra customerID

            Employee e = repository.Employees.ElementAt(EmployeeID - 1);
            newRes.Employee = e;

            int index = repository.Reservations.IndexOf(repository.Reservations.Find(x => x.ReservationID == newRes.ReservationID));

            repository.Reservations[index] = newRes;
            return View(newRes);
        }
    }
}