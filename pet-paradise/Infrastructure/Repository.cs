using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pet_paradise.Models;

namespace pet_paradise.Infrastructure
{
    public class Repository
    {
        // create dictionary collection for prices, and define property to get the collection

        Dictionary<string, int> prices = new Dictionary<string, int>();
        public Dictionary<string, int> Prices { get { return prices; } }
        Dictionary<string, string> hours = new Dictionary<string, string>();
        public Dictionary<string, string> Hours { get { return hours; } }
        // create List with Reservations, and define property to get the List
        List<Reservation> reservations = new List<Reservation>();
        public List<Reservation> Reservations { get { return reservations; } }
        //make a list of customers
        List<Customer> customers = new List<Customer>();
        public List<Customer> Customers { get { return customers; } }
        //Lav en liste af employees
        List<Employee> employees = new List<Employee>();
        public List<Employee> Employees { get { return employees; } }
        public Repository()
        {
            // add prices to the dictionary, prices
            prices.Add("Dog", 180);
            prices.Add("Cat", 140);
            prices.Add("Snake", 120);
            prices.Add("Guinea pig", 75);
            prices.Add("Canary", 60);
            //add opening hours to the dictionary, hours
            hours.Add("Monday", "9-17");
            hours.Add("Tuesday", "9-17");
            hours.Add("Wednesday", "9-17");
            hours.Add("Thursday", "9-17");
            hours.Add("Friday", "9-13");
            hours.Add("Saturday", "Closed");
            hours.Add("Sunday", "Closed");
            // create employees
            Employee e1 = new Employee(1, "Laura", "Johnson", "Mejlgade 8", "8000", 
            "Århus", "laura@johnson.com", "45454545");
            Employee e2 = new Employee(2, "Dennis", "Holm", "Randersvej 43", "8000",
            "Århus", "dennis@holm.com", "78787878");
            // create customers
            Customer c1 = new Customer(1, "Susan", "Peterson", "Borgergade 45",
            "8000", "Aarhus", "supe@xmail.dk", "21212121");
            Customer c2 = new Customer(2, "Brian", "Smith", "Algade 108",
            "8000", "Aarhus", "brsm@xmail.dk", "45454545");
            Reservation r1 = new Reservation(1, "Fido", "Dog",
            new DateTime(2014, 9, 2), new DateTime(2014, 9, 20), c1, e1);
            Reservation r2 = new Reservation(2, "Samson", "Dog",
            new DateTime(2014, 9, 14), new DateTime(2014, 9, 21), c1, e2);
            Reservation r3 = new Reservation(3, "Darla", "Cat",
            new DateTime(2014, 9, 7), new DateTime(2014, 9, 10), c2, e2);

            // add Reservations to list of Reservations with instance name reservations
            reservations.Add(r1);
            reservations.Add(r2);
            reservations.Add(r3);

            // add customers to list of customers
            customers.Add(c1);
            customers.Add(c2);

            //tilføj employees til listen af employees
            employees.Add(e1);
            employees.Add(e2);
        }
    }
}
    