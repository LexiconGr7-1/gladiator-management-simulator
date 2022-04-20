using Gladiator.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Gladiator.Presentation.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {

        private static List<Models.Gladiator> Gladiators = new()
        {
            new Models.Gladiator { Id = 1, Name = "Gladiator 1", Health = 1, Strength = 1 },
            new Models.Gladiator { Id = 2, Name = "Gladiator 2", Health = 2, Strength = 2 },
            new Models.Gladiator { Id = 3, Name = "Gladiator 3", Health = 3, Strength = 3 },
            new Models.Gladiator { Id = 4, Name = "Gladiator 4", Health = 4, Strength = 4 },
            new Models.Gladiator { Id = 5, Name = "Gladiator 5", Health = 5, Strength = 5 },
            new Models.Gladiator { Id = 6, Name = "Gladiator 6", Health = 6, Strength = 6 },
            new Models.Gladiator { Id = 7, Name = "Gladiator 7", Health = 7, Strength = 7 },
            new Models.Gladiator { Id = 8, Name = "Gladiator 8", Health = 8, Strength = 8 },
            new Models.Gladiator { Id = 9, Name = "Gladiator 9", Health = 9, Strength = 9 },
            new Models.Gladiator { Id = 10, Name = "Gladiator 10", Health = 10, Strength = 10 },
            new Models.Gladiator { Id = 11, Name = "Gladiator 11", Health = 11, Strength = 11 }
        };

        private static List<School> Schools = new()
        {
            new School { Id = 1, Name = "School 1", PlayerID = 1, Gladiators = Gladiators.GetRange(0, 3) },
            new School { Id = 2, Name = "School 2", PlayerID = 2, Gladiators = Gladiators.GetRange(3, 3) },
            new School { Id = 3, Name = "School 3", PlayerID = 3, Gladiators = Gladiators.GetRange(6, 3) },
            new School { Id = 4, Name = "School 4", PlayerID = 1, Gladiators = Gladiators.GetRange(10, 1) }
        };

        private static List<Player> Players = new()
        {
            new Player { Id = 1, Name = "Player 1", Gladiators = Gladiators.GetRange(0, 3), Schools = Schools.GetRange(0, 1) },
            new Player { Id = 2, Name = "Player 2", Gladiators = Gladiators.GetRange(3, 3), Schools = Schools.GetRange(1, 1) },
            new Player { Id = 3, Name = "Player 3", Gladiators = Gladiators.GetRange(6, 3), Schools = Schools.GetRange(2, 1) }
        };

        private static List<Arena> Arenas = new()
        {
            new Arena { Id = 1, Name = "Arena 1", Schools = Schools.GetRange(0, 2) },
            new Arena { Id = 2, Name = "Arena 2", Schools = Schools.GetRange(2, 1) }
        };

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            if (id < 1)
                return BadRequest();

            Player player = Players.Find(x => x.Id == id);

            string jsonString = JsonConvert.SerializeObject(player);

            return Ok(jsonString);
        }

        [HttpGet]
        public async Task<IActionResult> Getplayers()
        {
            string jsonString = JsonConvert.SerializeObject(Players);

            return Ok(jsonString);
        }

        [HttpGet("school/notinarena")]
        public async Task<IActionResult> GetSchoolNotInArena()
        {
            //Player id from Identity
            int playerId = 1;

            //var schools =
            //    from arena in Arenas
            //    from arenaSchools in arena.Schools
            //    from school in Schools
            //    where school.Id == playerId && arenaSchools.Id != school.Id
            //    select school;

            List<School> schools = new();

            //Arenas.ForEach(arena =>
            //{
            //    schools.ForEach(school =>
            //    {
            //        if (school.PlayerID == playerId)
            //        {
            //            arena.Schools.ForEach(arenaSchool =>
            //            {
            //                if(school.Id == arenaSchool.Id)
            //            });
            //        }
            //    });
            //});

            foreach(var school in Schools)
            {
                if(school.PlayerID == playerId)
                {
                    if (!SchoolInArena(school))
                    {
                        schools.Add(school);
                    }
                }
            }

            string jsonString = JsonConvert.SerializeObject(schools);

            return Ok(jsonString);
        }

        public bool SchoolInArena(School school)
        {
            //Arenas.ForEach(arena =>
            //{
            //    arena.Schools.ForEach((arenaSchool) =>
            //    {
            //        if (school.Id == arenaSchool.Id)
            //        {
            //            return true;
            //        }
            //    };
            //};

            foreach(var arena in Arenas)
            {
                foreach (var arenaSchool in arena.Schools)
                {
                    if(arenaSchool.Id == school.Id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // {"Id":1,"name":"Player5","schools":[{"id":5,"name":"School 5","playerID":5,"Gladiators":[{"id":11,"name":"Gladiator 11","health":11.0,"strength":11.0}]}],"gladiators":[{"id":11,"name":"Gladiator 11","health":11.0,"strength":11.0}]}

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(CreatePlayerDto playerDto)
        {
            var newPlayer = new Player();

            newPlayer.Id = (from p in Players
                            select p.Id).Max() + 1;

            newPlayer.Name = playerDto.Name;

            var newGladiator = new Models.Gladiator
            {
                Id = (from g in Gladiators
                      select g.Id).Max() + 1,
                Name = playerDto.Gladiator,
                Health = 10,
                Strength = 5
            };

            Gladiators.Add(newGladiator);

            var newSchool = new School
            {
                Name = playerDto.School,
                Id = (from s in Schools
                      select s.Id).Max() + 1,
                PlayerID = newPlayer.Id,
                Gladiators = new List<Models.Gladiator> { newGladiator }
            };

            Schools.Add(newSchool);

            newPlayer.Schools = new List<School> { newSchool };
            newPlayer.Gladiators = new List<Models.Gladiator> { newGladiator };

            Players.Add(newPlayer);

            string jsonString = JsonConvert.SerializeObject(newPlayer);

            return Ok(jsonString);
        }

        public class CreatePlayerDto
        {
            public string Name { get; set; }
            public string School { get; set; }
            public string Gladiator { get; set; }
        }

        // json example {"name": "Addicus","strength": 123,"health": 456}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePlayer(int id, Player player)
        {
            if (id < 1)
                return BadRequest();

            Player playerToUpdate = Players.SingleOrDefault(g => g.Id == id);

            if (playerToUpdate == null)
                return BadRequest();

            int index = Players.FindIndex(x => x.Id == id);

            playerToUpdate.Name = player.Name;
            
            //playerToUpdate.Schools = player.Schools;
            //playerToUpdate.Gladiators = player.Gladiators;
            Players[index] = playerToUpdate;

            string jsonString = JsonConvert.SerializeObject(Players);

            return Ok(jsonString);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            if (id < 1)
                return BadRequest();

            int index = Players.FindIndex(x => x.Id == id);

            if (index == -1)
                return BadRequest();

            Players.RemoveAt(index);

            string jsonString = JsonConvert.SerializeObject(Players);

            return Ok(jsonString);
        }
    }
}
