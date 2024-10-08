using DevDesafioMagvaBusZap.Models;
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
        #region Swagger
        /// <summary>
        /// Retrieves character data by requested parameters.
        /// </summary>
        /// <returns>
        /// A list of characters. 
        /// In case of an error, returns an <see cref="Error"/> object.
        /// </returns>
        /// <response code="200">Returns a list of characters</response>
        /// <response code="404">If no character is found</response>
        /// <response code="500">If there is an internal server error</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Character>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error))]
        #endregion
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
