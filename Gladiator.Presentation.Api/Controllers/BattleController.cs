﻿using Gladiator.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BattleController : Controller
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
            new Models.Gladiator { Id = 10, Name = "Gladiator 10", Health = 10, Strength = 10 }
        };

        private static List<School> Schools = new()
        {
            new School {Id = 1, Name = "School 1", PlayerID = 1, Gladiators = Gladiators.GetRange(0, 3)},
            new School {Id = 2, Name = "School 2", PlayerID = 2, Gladiators = Gladiators.GetRange(3, 3)},
            new School {Id = 3, Name = "School 3", PlayerID = 3, Gladiators = Gladiators.GetRange(6, 3)},
        };

        private static List<Player> Players = new()
        {
            new Player {Id = 1, Name = "Player 1", Gladiators = Gladiators.GetRange(0, 3), Schools = Schools.GetRange(0, 1)},
            new Player {Id = 2, Name = "Player 2", Gladiators = Gladiators.GetRange(3, 3), Schools = Schools.GetRange(1, 1)},
            new Player {Id = 3, Name = "Player 3", Gladiators = Gladiators.GetRange(6, 3), Schools = Schools.GetRange(2, 1)}
        };

        private static List<Arena> Arenas = new()
        {
            new Arena {Id = 1, Name = "Arena 1", Schools = Schools.GetRange(0, 2)},
            new Arena {Id = 2, Name = "Arena 2", Schools = Schools.GetRange(2, 1)}
        };

        [HttpGet("gladiator/player/{id:int}")]
        public IActionResult GetGladiatorsFromPlayerId(int id)
        {
            var gladiators =
                from player in Players
                where player.Id == id
                select player.Gladiators;

            return Ok(gladiators);
        }

        [HttpGet("arena/gladiator/{id:int}")]
        public IActionResult GetArenaFromGladiatorId(int id)
        {
            var gladiator = Gladiators.SingleOrDefault(g => g.Id == id);

            if (gladiator is null)
                return NotFound("Gladiator not found");

            var school = Schools.SingleOrDefault(s => s.Gladiators.Any(g => g.Id == gladiator.Id));
            
            if (school is null)
                return NotFound("Gladiator not in school");

            var arena = Arenas.SingleOrDefault(a => a.Schools.Any(s => s.Id == school.Id));

            if (arena is null)
                return NotFound("School not in arena");

            return Ok(arena);
        }

        [HttpGet("roster/gladiator/player/{id:int}")]
        public IActionResult GetGladiatorRosterFromPlayerId(int id)
        {
            // all player's gladiators

            
            return Ok();
        }

        [HttpGet("roster/opponent/gladiator/{id:int}")]
        public IActionResult GetOpponentRosterFromGladiatorId(int id)
        {
            // all other gladiators able to fight gladiator, in same area, not same player

            return Ok();
        }

        public class GladiatorBattleRosterDto
        {
            [JsonProperty("gladiators")]
            public List<GladiatorBattleDto> Gladiators { get; set; }
        }

        public class GladiatorBattleDto
        {
            [JsonProperty("gladiator")]
            public Models.Gladiator Gladiator { get; set; }
            [JsonProperty("arenaid")]
            public int ArenaId { get; set; }
            [JsonProperty("arenaname")]
            public string ArenaName { get; set; }
            [JsonProperty("playerid")]
            public int PlayerId { get; set; }
            [JsonProperty("playername")]
            public string PlayerName { get; set; }
            [JsonProperty("schoolid")]
            public int SchoolId { get; set; }
            [JsonProperty("schoolname")]
            public string SchoolName { get; set; }
        }
    }

}
