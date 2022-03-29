using Microsoft.AspNetCore.Mvc;

namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("/api")]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}