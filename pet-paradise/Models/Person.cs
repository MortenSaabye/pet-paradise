using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace pet_paradise.Models
{
    public class Person
    {
        [Display(Name = "First name:")]
        [Required()]
        public string Firstname { get; set; }

        [Display(Name = "Last name:")]
        [Required()]
        public string Lastname { get; set; }

        [Display(Name = "Address:")]
        [Required()]
        public string Address { get; set; }

        [Display(Name = "Zipcode:")]
        [Required()]
        public string Zipcode { get; set; }

        [Display(Name = "City:")]
        [Required()]
        public string City { get; set; }

        [Display(Name = "Email:")]
        [Required()]
        public string Email { get; set; }

        private string phone;

        [Display(Name = "Phone:")]
        [Required()]
        public string Phone
        {
            get { return phone; }
            set
            {
                if (value.Length >= 8)
                {
                    phone = value;
                }
                else
                {
                    throw new System.ArgumentException("Phonenumber must have at least 8 characters");
                }
            }
        }
        //constructor
        public Person() { }
        public Person(string firstname, string lastname, string address, string zipcode, 
        string city, string email, string phone)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Address = address;
            this.Zipcode = zipcode;
            this.City = city;
            this.Email = email;
            this.Phone = phone;
        }
    }
}