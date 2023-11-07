using PokemonAPI.Models;
using Refit;
using static PokemonAPI.Models.Details;

namespace PokemonAPI.Services
{
    public interface IPokeService
    {
        [Get("/pokemon")]
        Task<NamedAPIResourceList> GetAll(int limit);

        [Get("/pokemon/{id}")]
        Task<PokemonData> GetById(int id);
    }
}
