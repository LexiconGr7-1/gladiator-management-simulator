using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Gladiator.Presentation;
namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GladiatorController : ControllerBase
    {
        private static readonly Random random = new Random();

        private static List<Gladiator.Presentation.Models.Gladiator> gladiators = new()
        {
            new Gladiator.Presentation.Models.Gladiator
            {
                Name = "Gladiator 1",
                Id = 1,
                Strength = 1,
                Health = 1
            },
            new Gladiator.Presentation.Models.Gladiator
            {
                Name = "Gladiator 2",
                Id = 2,
                Strength = 2,
                Health = 2
            },
            new Gladiator.Presentation.Models.Gladiator
            {
                Name = "Gladiator 3",
                Id = 3,
                Strength = 3,
                Health = 3
            },
            new Gladiator.Presentation.Models.Gladiator
            {
                Name = "Gladiator 4",
                Id = 4,
                Strength = 4,
                Health = 4
            },
            new Gladiator.Presentation.Models.Gladiator
            {
                Name = "Gladiator 5",
                Id = 5,
                Strength = 5,
                Health = 5
            },
            new Gladiator.Presentation.Models.Gladiator
            {
                Name = "Gladiator 6",
                Id = 6,
                Strength = 6,
                Health = 6
            },
            new Gladiator.Presentation.Models.Gladiator
            {
                Name = "Gladiator 7",
                Id = 7,
                Strength = 7,
                Health = 7
            },
            new Gladiator.Presentation.Models.Gladiator
            {
                Name = "Gladiator 8",
                Id = 8,
                Strength = 8,
                Health = 8
            },
            new Gladiator.Presentation.Models.Gladiator
            {
                Name = "Gladiator 9",
                Id = 9,
                Strength = 9,
                Health = 9
            },
            new Gladiator.Presentation.Models.Gladiator
            {
                Name = "Gladiator 10",
                Id = 10,
                Strength = 10,
                Health = 10
            }
        };

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGladiator(int id)
        {
            if (id < 1)
                return BadRequest();

            Models.Gladiator gladiator = gladiators.Find(x => x.Id == id);

            string jsonString = JsonConvert.SerializeObject(gladiator);

            return Ok(jsonString);
        }

        [HttpGet]
        public async Task<IActionResult> GetGladiators()
        {
            string jsonString = JsonConvert.SerializeObject(gladiators);

            return Ok(jsonString);
        }

        [HttpGet("generate/{id}")]
        public async Task<IActionResult> GetRandomGladiator(int id, Difficulty difficulty)
        {
            if (id < 1)
                return BadRequest();

            Models.Gladiator currentGladiator = gladiators.SingleOrDefault(x => x.Id == id);

            if(currentGladiator == null)
                return BadRequest();

            var minHealth = currentGladiator.Health - Math.Abs(difficulty.Lower);
            var maxHealth = currentGladiator.Health + difficulty.Upper;

            var minStrength = currentGladiator.Strength - Math.Abs(difficulty.Lower);
            var maxStrength = currentGladiator.Strength + difficulty.Upper;

            minHealth = minHealth < 0 ? 0 : minHealth;
            minStrength = minStrength < 0 ? 0 : minStrength;

            maxHealth = maxHealth < 0 ? 0 : maxHealth;
            maxStrength = maxStrength < 0 ? 0 : maxStrength;

            Models.Gladiator newGladiator = new();

            newGladiator.Id = (from g in gladiators
                            select g.Id).Max() + 1;

            newGladiator.Name = "New Random Gladiator";
            newGladiator.Health = random.Next((int)minHealth, (int)maxHealth + 1);
            newGladiator.Strength = random.Next((int)minStrength, (int)maxStrength + 1);

            gladiators.Add(newGladiator);

            string jsonString = JsonConvert.SerializeObject(newGladiator);

            return Ok(jsonString);
        }

        public class Difficulty
        {
            [JsonProperty("upper")]
            public int Upper { get; set; }
            [JsonProperty("lower")]
            public int Lower { get; set; }
        }

        // json example {"name": "Addicus","strength": 123,"health": 456}
        [HttpPost]
        public async Task<IActionResult> CreateGladiator(Models.Gladiator gladiator)
        {
            gladiator.Id = (from g in gladiators
                            select g.Id).Max() + 1;

            gladiators.Add(gladiator);

            string jsonString = JsonConvert.SerializeObject(gladiator);

            return Ok(jsonString);
        }

        // json example {"name": "Addicus","strength": 123,"health": 456}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGladiator(int id, Models.Gladiator gladiator)
        {
            if (id < 1)
                return BadRequest();

            Models.Gladiator? gladiatorToUpdate = gladiators.FirstOrDefault(g => g.Id == id);

            if (gladiatorToUpdate == null)
                return BadRequest();

            int index = gladiators.FindIndex(x => x.Id == id);

            gladiatorToUpdate.Name = gladiator.Name;
            gladiatorToUpdate.Health = gladiator.Health;
            gladiatorToUpdate.Strength = gladiator.Strength;

            gladiators[index] = gladiatorToUpdate;

            string jsonString = JsonConvert.SerializeObject(gladiatorToUpdate);

            return Ok(jsonString);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGladiator(int id)
        {
            if (id < 1)
                return BadRequest();

            int index = gladiators.FindIndex(x => x.Id == id);

            if (index == -1)
                return BadRequest();

            gladiators.RemoveAt(index);

            return Ok();
        }
    }
}



