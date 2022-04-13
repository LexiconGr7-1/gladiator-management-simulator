using Gladiator.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BattleController : Controller
    {
        private static readonly Random random = new Random();

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
            new Models.Gladiator { Id = 11, Name = "Gladiator 11", Health = 11, Strength = 11 },
            new Models.Gladiator { Id = 12, Name = "Gladiator 12", Health = 12, Strength = 12 }
        };

        private static List<School> Schools = new()
        {
            new School { Id = 1, Name = "School 1", PlayerID = 1, Gladiators = Gladiators.GetRange(0, 3) },
            new School { Id = 2, Name = "School 2", PlayerID = 2, Gladiators = Gladiators.GetRange(3, 3) },
            new School { Id = 3, Name = "School 3", PlayerID = 3, Gladiators = Gladiators.GetRange(6, 3) },
            new School { Id = 4, Name = "School 4", PlayerID = 4, Gladiators = Gladiators.GetRange(9, 3) },
        };

        private static List<Player> Players = new()
        {
            new Player { Id = 1, Name = "Player 1", Gladiators = Gladiators.GetRange(0, 3), Schools = Schools.GetRange(0, 1) },
            new Player { Id = 2, Name = "Player 2", Gladiators = Gladiators.GetRange(3, 3), Schools = Schools.GetRange(1, 1) },
            new Player { Id = 3, Name = "Player 3", Gladiators = Gladiators.GetRange(6, 3), Schools = Schools.GetRange(2, 1) },
            new Player { Id = 4, Name = "Player 4", Gladiators = Gladiators.GetRange(9, 3), Schools = Schools.GetRange(3, 1) }
        };

        private static List<Arena> Arenas = new()
        {
            new Arena { Id = 1, Name = "Arena 1", Schools = Schools.GetRange(0, 2) },
            new Arena { Id = 2, Name = "Arena 2", Schools = Schools.GetRange(2, 2) }
        };

        private Arena ArenaFromGladiator(Models.Gladiator gladiator)
        {
            return Arenas.SingleOrDefault(
                a => a.Schools.Any(
                    s => s.Gladiators.Any(
                        g => g.Id == gladiator.Id)));
        }

        private Player PlayerFromGladiator(Models.Gladiator gladiator)
        {
            return Players.SingleOrDefault(
                p => p.Gladiators.Any(
                    g => g.Id == gladiator.Id));
        }

        private School SchoolFromGladiator(Models.Gladiator gladiator)
        {
            return Schools.SingleOrDefault(
                s => s.Gladiators.Any(
                    g => g.Id == gladiator.Id));
        }

        private bool GladiatorsCanFight(Models.Gladiator gladiator, Models.Gladiator opponent)
        {
            if (ArenaFromGladiator(gladiator) != ArenaFromGladiator(opponent))
                return false;

            if (PlayerFromGladiator(gladiator) == PlayerFromGladiator(opponent))
                return false;

            return true;
        }

        private List<GladiatorBattleDto> GladiatorRoster(List<Models.Gladiator> gladiators)
        {
            List<GladiatorBattleDto> gladiatorList = new();

            gladiators.ForEach(g =>
            {
                var arena = ArenaFromGladiator(g);
                var player = PlayerFromGladiator(g);
                var school = SchoolFromGladiator(g);

                gladiatorList.Add(new GladiatorBattleDto
                {
                    Gladiator = g,
                    ArenaId = arena?.Id ?? 0,
                    ArenaName = arena?.Name ?? "",
                    PlayerId = player?.Id ?? 0,
                    PlayerName = player?.Name ?? "",
                    SchoolId = school?.Id ?? 0,
                    SchoolName = school?.Name ?? ""
                });
            });

            return gladiatorList;
        }

        [HttpGet("roster/player/{id:int}")]
        public IActionResult GetGladiatorRoster(int id)
        {
            // get player id from Identity
            var playerId = id;

            var player = Players.SingleOrDefault(p => p.Id == playerId);

            if (player == null)
                return NotFound("Player not found");

            var roster = GladiatorRoster(player.Gladiators);

            return Ok(roster);
        }

        [HttpGet("opponents/gladiator/{id:int}")]
        public IActionResult GetOpponentRosterFromGladiatorId(int id)
        {
            var gladiator = Gladiators.SingleOrDefault(g => g.Id == id);

            if (gladiator == null)
                return NotFound("Gladiator not found");

            var arena = ArenaFromGladiator(gladiator);

            if (arena == null)
                return NotFound("Arena not found");

            List<Models.Gladiator> gladiators = new();

            var playerId = PlayerFromGladiator(gladiator).Id;

            arena.Schools.ForEach(s =>
            {
                if (s.PlayerID != playerId)
                {
                    s.Gladiators.ForEach(g =>
                    {
                        gladiators.Add(g);
                    });
                }
            });

            if (gladiators.Count == 0)
                return NotFound("No opponents found");

            var opponents = GladiatorRoster(gladiators);

            return Ok(opponents);
        }
        
        [HttpPost("gladiator/{id:int}")]
        public IActionResult BattleGladiators(int id, [FromBody] int opponentId )
        {
            var gladiator = Gladiators.SingleOrDefault(g => g.Id == id);

            if (gladiator == null)
                return NotFound("No gladiator found");

            var opponent = Gladiators.SingleOrDefault(g => g.Id == opponentId);

            if (opponent == null)
                return NotFound("No opponent found");

            if (!GladiatorsCanFight(gladiator, opponent))
                return BadRequest("Those gladiators can not fight");

            // battle logic
            var winner = random.Next() % 2 == 0 ? gladiator : opponent;

            return Ok(winner);
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
