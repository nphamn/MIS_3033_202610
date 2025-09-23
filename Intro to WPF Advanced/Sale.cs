using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Intro_To_WPF_Advanced
{
    public class Sale
    {
        public DateTime Transaction_date { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public string Payment_Type { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime Account_Created { get; set; }
        public DateTime Last_Login { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }


        public Sale()
        {
            Transaction_date = DateTime.Now;
            Product = string.Empty;
            Price = 0.00;
            Payment_Type = string.Empty;
            Name = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Country = string.Empty;
            Account_Created = DateTime.Now;
            Last_Login = DateTime.Now;
            Latitude = 0.00M;
            Longitude = 0.00M;
        }



    }

}
