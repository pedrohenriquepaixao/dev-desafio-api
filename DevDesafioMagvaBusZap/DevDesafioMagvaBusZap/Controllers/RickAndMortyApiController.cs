using DevDesafioMagvaBusZap.Models.Results;
using DevDesafioMagvaBusZap.Service;
using DevDesafioMagvaBusZap.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DevDesafioMagvaBusZap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RickAndMortyApiController : ControllerBase
    {
        private readonly IApiService _apiService;
        public RickAndMortyApiController(IApiService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _apiService.GetDataByRequestedParameters();

            return result.Match<IActionResult>(
                    onSuccess: () => Ok(result.Value),
                    onFailure: error => BadRequest(error.Description)
                );
        }
    }
}
