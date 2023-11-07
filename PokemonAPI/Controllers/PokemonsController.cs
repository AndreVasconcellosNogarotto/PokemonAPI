using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Services;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private const string TOKEN = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        private readonly IPokeService pokeService;
        private readonly IExternalService externalService;

        public PokemonsController(IPokeService pokeService, IExternalService externalService)
        {
            this.pokeService = pokeService;
            this.externalService = externalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int limit)
        {
            var result = await pokeService.GetAll(limit);

            var viewModelList = result.MapToViewModel();

            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await pokeService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ping ping)
        {
            var result = await externalService.GetData(ping, TOKEN);

            return Ok(result);
        }
    } 


    public class Ping
    {
        public string Message { get; set; }
    }

    public class ExternalResponse
    {
        public List<string> Headers { get; set; }
        public Ping Data { get; set; }
    }
}
