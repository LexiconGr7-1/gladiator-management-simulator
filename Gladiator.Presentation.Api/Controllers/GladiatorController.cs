using Microsoft.AspNetCore.Mvc;
using System;

namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GladiatorController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGladiator(int id)
        {
            if (id < 1)
                return BadRequest();

            string gladiator = "Gladiator: " + id;

            return Ok(gladiator);
        }

        [HttpGet]
        public async Task<IActionResult> GetGladiators()
        {
            string[] gladiators = new string[]
            {
                "Gladiator1",
                "Gladiator2",
                "Gladiator3",
                "Gladiator4"
            };

            return Ok(gladiators);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGladiator(object gladiator)
        {
            if (gladiator == null)
                return BadRequest();

            string NewGladiator = "CreateGladiator: " + gladiator.ToString();

            return Ok(NewGladiator);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGladiator(int id, object gladiator)
        {
            if (gladiator == null || id < 1)
                return BadRequest();

            string UpdateGladiator = "UpdateGladiator: " + id + " to " + gladiator.ToString();

            return Ok(UpdateGladiator);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGladiator(int id)
        {
            if (id < 1)
                return BadRequest();

            string DeleteGladiator = "DeleteGladiator: " + id;

            return Ok(DeleteGladiator);
        }
    }
}
