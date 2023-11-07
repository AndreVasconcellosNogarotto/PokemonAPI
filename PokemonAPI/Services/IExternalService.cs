using PokemonAPI.Controllers;
using Refit;

namespace PokemonAPI.Services
{
    public interface IExternalService
    {
        [Post("/api/random")]
        [Headers("X-Andre-DevBlog: https://google.com")]
        Task<ExternalResponse> GetData(Ping ping, [Header("Authorization")] string token);
    }
}
