using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Gladiator.Presentation.Models;
namespace Gladiator.Presentation.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
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
        { new School
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
        static List<Models.Gladiator> gladiators5 = gladiators3.Concat(gladiators4).ToList();

        static List<Player> players = new()
        {
            new Player
            {
                Name = "Player1",
                Id = 1,
                Schools = schools1,
                Gladiators = gladiators1
            },
            new Player
            {
                Name = "Player2",
                Id = 2,
                Schools = schools2,
                Gladiators = gladiators2
            },
            new Player
            {
                Name = "Player3",
                Id = 3,
                Schools = schools3,
                Gladiators = gladiators5
            }
        };


        static List<Models.Gladiator> gladiators6 = new()
        {
            new Models.Gladiator
            {
                Name = "Gladiator 11",
                Id = 11,
                Strength = 11,
                Health = 11
            },
        };
        static List<School> schools7 = new()
        {
            new School
            {
                Name = "School 5",
                Id = 5,
                PlayerID = 5,
                Gladiators = gladiators6,
            },
        };
        static List<School> schools4 = schools1.Concat(schools2).Concat(schools3).Concat(schools7).ToList();
        static List<Models.Gladiator> gladiators7 = gladiators1.Concat(gladiators2).Concat(gladiators5).Concat(gladiators6).ToList();
       
        [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPlayer(int id)
    {
        if (id < 1)
            return BadRequest();

        Player player = players.Find(x => x.Id == id);

        string jsonString = JsonConvert.SerializeObject(player);

        return Ok(jsonString);
    }

    [HttpGet]
    public async Task<IActionResult> Getplayers()
    {
        string jsonString = JsonConvert.SerializeObject(players);

        return Ok(jsonString);
        }

       // {"Id":1,"name":"Player5","schools":[{"id":5,"name":"School 5","playerID":5,"Gladiators":[{"id":11,"name":"Gladiator 11","health":11.0,"strength":11.0}]}],"gladiators":[{"id":11,"name":"Gladiator 11","health":11.0,"strength":11.0}]}
    
    [HttpPost]
    public async Task<IActionResult> CreatePlayer(Player player)
    {
            player.Id = (from g in players
                         select g.Id).Max() + 1;

            foreach (Player y in players)
            { foreach (School x in y.Schools)
                    foreach (School z in player.Schools)
                    {
                        if (x.Id == z.Id)
                        { return BadRequest(); }
                    } 
            }
            foreach (Player y in players)
            {
                foreach (Models.Gladiator x in y.Gladiators)
                    foreach (Models.Gladiator z in player.Gladiators)
                    {
                        if (x.Id == z.Id)
                        { return BadRequest(); }
                    }
            }
            foreach (School x in player.Schools)
            { 
                 if (schools4.FindIndex(g => g.Id == x.Id)<0 )
                
                { return BadRequest(); } 
            }
            foreach (Models.Gladiator x in player.Gladiators)
            {
                 if (gladiators7.FindIndex(g => g.Id == x.Id)<0) 
              
                { return BadRequest(); }
            }

            string jsonString = JsonConvert.SerializeObject(player);

            return Ok(jsonString);

        }
               

    // json example {"name": "Addicus","strength": 123,"health": 456}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePlayer(int id, Player player)
    {
        if (id < 1)
            return BadRequest();

        Player? playerToUpdate = players.FirstOrDefault(g => g.Id == id);

        if (playerToUpdate == null)
            return BadRequest();

        int index = players.FindIndex(x => x.Id == id);

        playerToUpdate.Name = player.Name;

            foreach (Player y in players)
            {
                foreach (School x in y.Schools)
                    foreach (School z in player.Schools)
                    {
                        if (x.Id == z.Id && y.Id!=player.Id)
                        { return BadRequest(); }
                    }
            }
            foreach (Player y in players)
            {
                foreach (Models.Gladiator x in y.Gladiators)
                    foreach (Models.Gladiator z in player.Gladiators)
                    {
                        if (x.Id == z.Id && y.Id != player.Id)
                        { return BadRequest(); }
                    }
            }
            foreach (School x in player.Schools)
            {
                if (schools4.FindIndex(g => g.Id == x.Id) < 0)

                { return BadRequest(); }
            }
            foreach (Models.Gladiator x in player.Gladiators)
            {
                if (gladiators7.FindIndex(g => g.Id == x.Id) < 0)

                { return BadRequest(); }
            }
            playerToUpdate.Schools = player.Schools;
            playerToUpdate.Gladiators = player.Gladiators;
            players[index] = playerToUpdate;

        string jsonString = JsonConvert.SerializeObject(players);

        return Ok(jsonString);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePlayer(int id)
    {
        if (id < 1)
            return BadRequest();

        int index = players.FindIndex(x => x.Id == id);

        if (index == -1)
            return BadRequest();

        players.RemoveAt(index);

        string jsonString = JsonConvert.SerializeObject(players);

        return Ok(jsonString);
    }
}
}
    


