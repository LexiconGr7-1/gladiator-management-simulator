using Gladiator.Application.Gladiator.Commands;
using Gladiator.Application.Gladiator.Queries;
using Gladiator.Application.Gladiator.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GladiatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GladiatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGladiator(int id)
        {


            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Core.Entities.Gladiator>> GetAllGladiators()
        {
            return await _mediator.Send(new GetAllGladiatorsQuery());
        }

        [HttpPost("generate/{id}")]
        public async Task<IActionResult> CreateRandomGladiator(
            int id, 
            [FromBody] CreateRandomGladiatorCommand createRandomGladiatorCommand)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGladiator(
            [FromBody] CreateGladiatorCommand createGladiatorCommand)
        {
            return Ok();
        }

        [HttpPut("fight/{id:int}")]
        public async Task<IActionResult> FightGladiator(int id)
            //[FromBody] FightGladiatorCommand fightGladiatorCommand)
        {
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGladiator(int id)
            //[FromBody] UpdateGladiatorCommand updateGladiatorCommand)
        {
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGladiator(int id)
        {
            return Ok();
        }
    }
}
