using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DB_Associative_Populating
{
    public class DogInput
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string Image { get; set; }

        public int? OwnerId { get; set; }
        public override string ToString()
        {
            return$"{Name} : {Breed} owned by {OwnerId}";
        }
    }
}
