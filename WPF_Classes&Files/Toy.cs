using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WPF_Classes_Files
// Replace lines where Toy is constructed with the simplified 'new' expression
{ 
   public class Toy
    {
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        private string Aisle { get; set; }

        public Toy(string manufacturer, string name, double price, string image)
        {
            Manufacturer = manufacturer;
            Name = name;
            Price = price;
            Image = image;
        }

        public string GetAisle()
        {
            
            string firstletter = Manufacturer[0].ToString();

            string price = string.Concat(Price.ToString().Where(char.IsDigit));

            string aisle = (firstletter + price).ToUpper();

            return aisle;
        }

        public override string ToString()
        {
            return $"{Manufacturer} - {Name}";
        }
    }

  

}
