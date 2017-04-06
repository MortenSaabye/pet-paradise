using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pet_paradise.Models
{
    public class Customer : Person
    {
        public int CustomerID { get; set; }
        
        
        //constructor
        public Customer() { }

        public Customer(int customerID, string firstname, string lastname, string address, 
        string zipcode, string city, string email, string phone) 
            : base (firstname, lastname, address, zipcode, city, email, phone )
        {
            this.CustomerID = customerID;
        }
    }
}