using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pet_paradise.Models
{
    public class Employee : Person
    {
        public int EmployeeID { get; set; }
        public string Initials { get; set; }
        public List<Reservation> Reservations {get; set;}

        //methods
        public void AddReservation(Reservation reservation)
        {
            Reservations.Add(reservation);
        }

        // constructors
        public Employee() { }

        public Employee(int employeeID, string firstname, string lastname, 
        string address, string zipcode, string city, string email, string phone)
            :base (firstname,lastname,address,zipcode,city,email,phone)
        {
            this.EmployeeID = employeeID;
            Initials = firstname.Substring(0, 1) + lastname.Substring(0, 2); 
        }
    }
}