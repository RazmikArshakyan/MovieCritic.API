using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCritic.Core.Services;

namespace MovieCritic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        // Here I create GptService object;
        private readonly IGptService gptService;
        public RequestsController(IGptService _gptService)
        {
            // And assign it in Controllers ctor with the service it gets as an argument
            gptService = _gptService;
        }

        /// <summary>
        /// With this HttpRequest I call Request function of interface, which finds response from the database
        /// according to my param name which is wanted movie
        /// </summary>
        /// <param name="wantedMovie"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SendRequest(string wantedMovie)
        {
            return Ok(gptService.Request(wantedMovie));
        }
    }
}
