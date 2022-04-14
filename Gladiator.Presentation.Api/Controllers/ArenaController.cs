using Gladiator.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArenaController : ControllerBase
    {
        private static List<Models.Gladiator> gladiators = new()
        {
            new Models.Gladiator { Name = "Gladiator 1", Id = 1, Strength = 1, Health = 1 },
            new Models.Gladiator { Name = "Gladiator 2", Id = 2, Strength = 2, Health = 2 },
            new Models.Gladiator { Name = "Gladiator 3", Id = 3, Strength = 3, Health = 3 },
            new Models.Gladiator { Name = "Gladiator 4", Id = 4, Strength = 4, Health = 4 },
            new Models.Gladiator { Name = "Gladiator 5", Id = 5, Strength = 5, Health = 5 },
            new Models.Gladiator { Name = "Gladiator 6", Id = 6, Strength = 6, Health = 6 },
            new Models.Gladiator { Name = "Gladiator 7", Id = 7, Strength = 7, Health = 7 },
            new Models.Gladiator { Name = "Gladiator 8", Id = 8, Strength = 8, Health = 8 },
            new Models.Gladiator { Name = "Gladiator 9", Id = 9, Strength = 9, Health = 9 },
            new Models.Gladiator { Name = "Gladiator 10", Id = 10, Strength = 10, Health = 10 },
            new Models.Gladiator { Name = "Gladiator 11", Id = 11, Strength = 11, Health = 11 }
        };

        private static List<School> schools = new()
        {
            new School { Name = "School 1", Id = 1, PlayerID = 1, Gladiators = gladiators.GetRange(0, 2) },
            new School { Name = "School 2", Id = 2, PlayerID = 2, Gladiators = gladiators.GetRange(2, 2) },
            new School { Name = "School 3", Id = 3, PlayerID = 3, Gladiators = gladiators.GetRange(4, 2) },
            new School { Name = "School 4", Id = 4, PlayerID = 4, Gladiators = gladiators.GetRange(6, 3) },
            new School { Name = "School 5", Id = 5, PlayerID = 5, Gladiators = gladiators.GetRange(9, 1) },
        };

        private static List<Arena> arenas = new()
        {
            new Arena { Name = "Arena 1", Id = 1, Schools = schools.GetRange(0, 1) },
            new Arena { Name = "Arena 2", Id = 2, Schools = schools.GetRange(1, 2) },
            new Arena { Name = "Arena 3", Id = 3, Schools = schools.GetRange(3, 1) },
        };

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetArenas(int id)
        {
            if (id < 1)
                return BadRequest();

            Arena arena = arenas.Find(x => x.Id == id);

            string jsonString = JsonConvert.SerializeObject(arena);

            return Ok(jsonString);
        }

        [HttpGet]
        public async Task<IActionResult> GetArenas()
        {
            string jsonString = JsonConvert.SerializeObject(arenas);

            return Ok(jsonString);
        }

        // {"name":"Arena 4","schools":[{"id":5,"name":"School 5","playerID":5,"Gladiators":[{"id":11,"name":"Gladiator 11","health":11,"strength":11}]}]}
        [HttpPost]
        public async Task<IActionResult> CreateArena(Arena arena)
        {

            if (arena.Schools != null)
            {
                if (GladiatorInOtherSchool(arena))
                    return BadRequest("Gladiator in other school");

                if (SchoolInOtherArena(arena))
                    return BadRequest("School is in other arena");
            }

            arena.Id = (from g in arenas
                        select g.Id).Max() + 1;

            arenas.Add(arena);

            string jsonString = JsonConvert.SerializeObject(arena);

            return Ok(jsonString);

        }

        // {"name":"Arena 1 - Updated","schools":[{"id":10,"name":"School 10","playerID":1,"gladiators":[{"id":20,"name":"Gladiator 20","health":1,"strength":1}]}]}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateArena(int id, Arena arena)
        {
            if (id < 1)
                return BadRequest();

            Arena arenaToUpdate = arenas.FirstOrDefault(g => g.Id == id);

            if (arenaToUpdate == null)
                return BadRequest();

            if (SchoolInOtherArena(arena))
                return BadRequest("School is in other arena");

            if (GladiatorInOtherSchool(arena))
                return BadRequest("Gladiator in other school");

            arenaToUpdate.Name = arena.Name;
            arenaToUpdate.Schools = arenaToUpdate.Schools.Concat(arena.Schools).ToList();

            int index = arenas.FindIndex(x => x.Id == id);
            arenas[index] = arenaToUpdate;

            string jsonString = JsonConvert.SerializeObject(arenas);

            return Ok(jsonString);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteArena(int id)
        {
            if (id < 1)
                return BadRequest();

            int index = arenas.FindIndex(x => x.Id == id);

            if (index == -1)
                return BadRequest();

            arenas.RemoveAt(index);

            string jsonString = JsonConvert.SerializeObject(arenas);

            return Ok(jsonString);
        }

        private bool SchoolInOtherArena(Arena arena)
        {
            return (
                from a in arenas
                where arena.Id == 0 || arena.Id != a.Id
                from s in arena.Schools
                from ss in a.Schools
                where s.Id == ss.Id
                select s
            ).Any();
        }

        private bool GladiatorInOtherSchool(Arena arena)
        {
            return (
                from a in arenas
                where arena.Id == 0 || arena.Id != a.Id
                from ga in a.Gladiators
                from g in arena.Gladiators
                where ga.Id == g.Id
                select g
            ).Any();
        }
    }
}

