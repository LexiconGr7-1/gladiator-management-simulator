using Microsoft.AspNetCore.Mvc;

namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : ControllerBase
    {

        private readonly ILogger<TemplateController> _logger;

        public TemplateController(ILogger<TemplateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            string Test = "test";
            return Test;

        }
    }
}