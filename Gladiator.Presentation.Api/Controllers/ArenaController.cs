using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Gladiator.Presentation.Models;
namespace Gladiator.Presentation.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ArenaController : ControllerBase
    {
        

        static List<Models.Gladiator> gladiators1 = new()
        {
            new Models.Gladiator
            {
                Name = "Gladiator 1",
                Id = 1,
                Strength = 1,
                Health = 1
            },
            new Models.Gladiator
            {
                Name = "Gladiator 2",
                Id = 2,
                Strength = 2,
                Health = 2
            },
        };
        static List<Models.Gladiator> gladiators2 = new()
        {
            new Models.Gladiator
            {
                Name = "Gladiator 3",
                Id = 3,
                Strength = 3,
                Health = 3
            },
            new Models.Gladiator
            {
                Name = "Gladiator 4",
                Id = 4,
                Strength = 4,
                Health = 4
            },
        };

        static List<Models.Gladiator> gladiators3 = new()
        {
            new Models.Gladiator
            {
                Name = "Gladiator 5",
                Id = 5,
                Strength = 5,
                Health = 5
            },
            new Models.Gladiator
            {
                Name = "Gladiator 6",
                Id = 6,
                Strength = 6,
                Health = 6
            },
        };
        static List<Models.Gladiator> gladiators4 = new()
        {
            new Models.Gladiator
            {
                Name = "Gladiator 7",
                Id = 7,
                Strength = 7,
                Health = 7
            },
            new Models.Gladiator
            {
                Name = "Gladiator 8",
                Id = 8,
                Strength = 8,
                Health = 8
            },
            new Models.Gladiator
            {
                Name = "Gladiator 9",
                Id = 9,
                Strength = 9,
                Health = 9
            },
            new Models.Gladiator
            {
                Name = "Gladiator 10",
                Id = 10,
                Strength = 10,
                Health = 10
            }
        };
        static List<Models.Gladiator> gladiators5 = new()
        {
            new Models.Gladiator
            {
                Name = "Gladiator 11",
                Id = 11,
                Strength = 11,
                Health = 11
            },
        };
        private static List<School> schools1 = new()
        {
            new School
            {
                Name = "School 1",
                Id = 1,
                PlayerID = 1,
                Gladiators = gladiators1,
            },
        };
        private static List<School> schools2 = new()
        {
            new School
            {
                Name = "School 2",
                Id = 2,
                PlayerID = 2,
                Gladiators = gladiators2,
            },
        };
        private static List<School> schools3 = new()
        {
            new School
            {
                Name = "School 3",
                Id = 3,
                PlayerID = 3,
                Gladiators = gladiators3,
            },
            new School
            {
                Name = "School 4",
                Id = 4,
                PlayerID = 3,
                Gladiators = gladiators4,
            },

        };
        private static List<School> schools4 = new()
        {
            new School
            {
                Name = "School 5",
                Id = 5,
                PlayerID = 3,
                Gladiators = gladiators5,
            },
        };
      public  static List<School> schools5 = schools1.Concat(schools2).Concat(schools3).Concat(schools4).ToList();
      public  static List<Models.Gladiator> gladiators7 = gladiators1.Concat(gladiators2).Concat(gladiators3).Concat(gladiators4).Concat(gladiators5).ToList();

        static List<Arena> arenas= new ()
                { 
                   new Arena
                  {
                    Name = "arena1",
                    Id=1,
                    Gladiators=gladiators1,
                    Schools=schools1,  
                  },
                 new Arena
                {   Name = "arena2",
                     Id = 2,
                     Gladiators =gladiators2,
                    Schools=schools2,
                  },
             new Arena
                 { Name = "arena3",
                 Id = 3,
                 Gladiators = gladiators3,
                    Schools = schools3,
                  },
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

        // {"Id":1,"name":"Player5","schools":[{"id":5,"name":"School 5","playerID":5,"Gladiators":[{"id":11,"name":"Gladiator 11","health":11.0,"strength":11.0}]}],"gladiators":[{"id":11,"name":"Gladiator 11","health":11.0,"strength":11.0}]}

        [HttpPost]
        public async Task<IActionResult> CreateArena(Arena arena)
        {
             arena.Id = (from g in arenas
                         select g.Id).Max() + 1;

            foreach (Arena y in arenas)
            {
                foreach (School x in y.Schools)
                    foreach (School z in arena.Schools)
                    {
                        if (x.Id == z.Id)
                        { return BadRequest(); }
                    }
            }
            foreach (Arena y in arenas)
            {
                foreach (Models.Gladiator x in y.Gladiators)
                    foreach (Models.Gladiator z in arena.Gladiators)
                    {
                        if (x.Id == z.Id)
                        { return BadRequest(); }
                    }
            }
            foreach (School x in arena.Schools)
            {
                if (schools5.FindIndex(g => g.Id == x.Id) < 0)

                { return BadRequest(); }
            }
            foreach (Models.Gladiator x in arena.Gladiators)
            {
                if (gladiators7.FindIndex(g => g.Id == x.Id) < 0)

                { return BadRequest(); }
            }

            string jsonString = JsonConvert.SerializeObject(arena);

            return Ok(jsonString);

        }


        // json example {"name": "Addicus","strength": 123,"health": 456}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePlayer(int id, Arena arena)
        {
            if (id < 1)
                return BadRequest();

            Arena? arenaToUpdate = arenas.FirstOrDefault(g => g.Id == id);

            if (arenaToUpdate == null)
                return BadRequest();

            int index = arenas.FindIndex(x => x.Id == id);

            arenaToUpdate.Name = arena.Name;

            foreach (Arena y in arenas)
            {
                foreach (School x in y.Schools)
                    foreach (School z in arena.Schools)
                    {
                        if (x.Id == z.Id && y.Id != arena.Id)
                        { return BadRequest(); }
                    }
            }
            foreach (Arena y in arenas)
            {
                foreach (Models.Gladiator x in y.Gladiators)
                    foreach (Models.Gladiator z in arena.Gladiators)
                    {
                        if (x.Id == z.Id && y.Id != arena.Id)
                        { return BadRequest(); }
                    }
            }
            foreach (School x in arena.Schools)
            {
                if (schools5.FindIndex(g => g.Id == x.Id) < 0)

                { return BadRequest(); }
            }
            foreach (Models.Gladiator x in arena.Gladiators)
            {
                if (gladiators7.FindIndex(g => g.Id == x.Id) < 0)

                { return BadRequest(); }
            }
            arenaToUpdate.Schools = arena.Schools;
            arenaToUpdate.Gladiators = arena.Gladiators;
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
    }
}
    
