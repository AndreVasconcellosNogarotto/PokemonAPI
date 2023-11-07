using Newtonsoft.Json;
using static PokemonAPI.Models.NamedAPIResourceList;

namespace PokemonAPI.Models
{
    public class NamedAPIResource
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public class PokemonListItemViewModel
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }
    }
}
