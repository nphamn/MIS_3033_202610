using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Pokemon
{
    public class PokemonDetail
    {
        public string? Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Sprites? Sprites { get; set; }
    }

    public class Sprites
    {
        public string? front_default { get; set; }
        public string? back_default { get; set; }
    }
}
