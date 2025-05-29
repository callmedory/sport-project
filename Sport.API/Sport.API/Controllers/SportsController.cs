using Microsoft.AspNetCore.Mvc;
using Sport.Models.DTOModels.Articles;
using Sport.Services.Interfaces;
using Swashbuckle.Swagger.Annotations;

namespace Sport.API.Controllers
{
    [Route("sports")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ISportsService _sportsService;

        public SportsController(ISportsService sportsService)
        {
            _sportsService = sportsService;
        }

        /// <summary>
        /// Get list of sport types.
        /// </summary>
        /// <returns>A list of sport types.</returns>
        [HttpGet]
        [SwaggerResponse(200, "Request_Succeeded", typeof(List<SportsDTO>))]
        public async Task<IActionResult> GetSportTypes()
        {
            var list = await _sportsService.GetSportTypes();
            return Ok(list);
        }
    }
}
