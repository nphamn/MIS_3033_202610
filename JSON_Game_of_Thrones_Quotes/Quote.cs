using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Game_of_Thrones_Quotes
{
    public class Quote
    {
        public string Sentence { get; set; } // This corresponds to the "sentence" field in the API response
        public Character Character { get; set; } // This corresponds to the "character" field (now an object)
    }

    public class Character
    {
        public string Name { get; set; } // Corresponds to the "name" field inside the "character" object
        public string Slug { get; set; } // Corresponds to the "slug" field inside the "character" object
        public House House { get; set; } // Corresponds to the "house" object inside the "character" object
    }

    public class House
    {
        public string Name { get; set; } // Corresponds to the "name" field inside the "house" object
        public string Slug { get; set; } // Corresponds to the "slug" field inside the "house" object
    }

}
