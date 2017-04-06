using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace pet_paradise.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }

        [Display(Name = "Name of your pet:")]
        [Required()]
        public string PetName { get; set; }

        public DateTime Birthdate { get; set; }

        [Display(Name = "Specie:")]
        public string Specie { get; set; }

        [Display(Name = "Arrival:")]
        [DataType(DataType.Date)]
        [Required()]
        public DateTime StartDate { get; set; }

        [Display(Name = "Departure:")]
        [DataType(DataType.Date)]
        [Required()]
        public DateTime EndDate { get; set; }

        [Display(Name = "Customer:")]
        public Customer Customer { get; set; }

        [Display(Name = "Employee:")]
        public Employee Employee { get; set; }


        //constructor
        public Reservation() { }

        public Reservation(int reservationID, string petname, string specie, DateTime startDate, 
        DateTime endDate, Customer customer)
        {
            this.ReservationID = reservationID;
            this.PetName = petname;
            this.Specie = specie;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Customer = customer;
        }
        public Reservation(int reservationID, string petname, string specie, DateTime startDate,
        DateTime endDate, Customer customer, Employee employee)
        {
            this.ReservationID = reservationID;
            this.PetName = petname;
            this.Specie = specie;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Customer = customer;
            this.Employee = employee;
        }
    }
}