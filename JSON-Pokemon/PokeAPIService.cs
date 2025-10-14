using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JSON_Pokemon
{
    // This service interacts with the PokéAPI to fetch details of Pokémon
    public class PokeAPIService
    {
        private static readonly HttpClient client = new HttpClient();

        // Fetch detailed information about a specific Pokémon
        public async Task<PokemonDetail> GetPokemonDetailAsync(string name)
        {
            try
            {
                // Ensure the name is valid before forming the URL
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException("The Pokémon name cannot be null or empty.");

                // Get the JSON response from the API
                var response = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{name}");

                // Check if the response is valid
                if (string.IsNullOrEmpty(response))
                    throw new InvalidOperationException("Empty response from the Pokémon API.");

                // Deserialize the response into the model
                var pokemonDetail = JsonConvert.DeserializeObject<PokemonDetail>(response);

                if (pokemonDetail == null)
                    throw new InvalidOperationException($"Unable to deserialize Pokémon details for {name}.");

                return pokemonDetail;
            }
            catch (Exception ex)
            {
                // Handle any exceptions and log the error (optional, for debugging)
                Console.WriteLine($"Error fetching Pokémon details for {name}: {ex.Message}");

                // Return an empty or default PokemonDetail if an error occurs
                return new PokemonDetail();
            }
        }

        // Fetch a list of Pokémon names (Optional if you need this functionality)
        public async Task<List<PokemonListItem>> GetPokemonListAsync()
        {
            try
            {
                var response = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?limit=1000");
                var pokemonList = JsonConvert.DeserializeObject<PokemonListResponse>(response);

                if (pokemonList == null || pokemonList.Results == null)
                    throw new InvalidOperationException("Unable to retrieve the Pokémon list.");

                return pokemonList.Results;
            }
            catch (Exception ex)
            {
                // Handle error (log it or notify the user)
                Console.WriteLine($"Error fetching Pokémon list: {ex.Message}");
                return new List<PokemonListItem>(); // Return an empty list in case of error
            }
        }
    }
    public class PokemonListResponse
    {
        public List<PokemonListItem>? Results { get; set; }
    }
}