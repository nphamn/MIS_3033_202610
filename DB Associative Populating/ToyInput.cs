using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Associative_Populating
{
    public class ToyInput
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string HasSqueeker { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
