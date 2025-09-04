using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;


namespace Cereal_Problem
{
    public class Cereal
    {
        //{
        //    private string Manufacturer;
        //    public string GetMenufacturer()
        //    {
        //        return Manufacturer;
        //    }
        //    private void SetManufacturer(string manufacturer)
        //    {
        //        Manufacturer = manufacturer;
        //    }
        //}

        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        /// <summary>
        /// Number of cups in a serving
        /// </summary>
        public double Cups { get; set; }

        private double Squirrel;

        /// <summary>
        /// Default/Empty Constructor to create an empty cereal object
        /// </summary>

        public Cereal()
        {
            Manufacturer = "";
            Name = string.Empty;
            Calories = 0;
            Cups = 0;
            Squirrel = 0;
        }

        public Cereal(string line)//: this() // Calls the default constructor to initialize properties
        {
            Manufacturer = line;

        }
        public override string ToString()
        {
            return $"{Name} is made by {Manufacturer}, has {Calories} calories and comes in {Cups} cups.";
        }

    }


}
