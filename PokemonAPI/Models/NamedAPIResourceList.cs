using Newtonsoft.Json;
using static PokemonAPI.Models.NamedAPIResource;

namespace PokemonAPI.Models
{
    public class NamedAPIResourceList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public NamedAPIResource[] Results { get; set; }

        public PokemonListViewModel MapToViewModel()
        {
            return new PokemonListViewModel
            {
                Count = Count,
                Pokemons = Results.Select(p =>
                {
                    var lastSegment = new Uri(p.Url).Segments.Last();
                    var id = lastSegment.Remove(lastSegment.Length - 1);

                    return new PokemonListItemViewModel { Name = p.Name, Id = int.Parse(id) };
                })
            };
        }
       
    }

    public class PokemonListViewModel
    {
        public int Count { get; set; }
        public IEnumerable<PokemonListItemViewModel> Pokemons { get; set; }
    }
}
