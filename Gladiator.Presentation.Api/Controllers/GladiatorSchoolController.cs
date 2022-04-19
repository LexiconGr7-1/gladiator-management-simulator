using Gladiator.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : ControllerBase
    {

        static List<Gladiator.Presentation.Models.Gladiator> gladiators1 = new()
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
        };
        static List<Gladiator.Presentation.Models.Gladiator> gladiators2 = new()
        {
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
        };
        static List<Gladiator.Presentation.Models.Gladiator> gladiators3 = new()
        {
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
        };
        static List<Gladiator.Presentation.Models.Gladiator> gladiators4 = new()
        {
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

        private static List<School> schools = new()
        {
            new School
            {
                Name = "School 1",
                Id = 1,
                PlayerID = 1,
                Gladiators = gladiators1,
            },
            new School
            {
                Name = "School 2",
                Id = 2,
                PlayerID = 2,
                Gladiators = gladiators2,
            },
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
                PlayerID = 4,
                Gladiators = gladiators4,
            },

        };

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSchool(int id)
        {
            if (id < 1)
                return BadRequest();

            School school = schools.Find(x => x.Id == id);

            string jsonString = JsonConvert.SerializeObject(school);

            return Ok(jsonString);
        }
        [HttpGet]
        public async Task<IActionResult> GetSchools()
        {
            string jsonString = JsonConvert.SerializeObject(schools);

            return Ok(jsonString);
        }
        // json example {"name": "Ludus Magnus","playerID": 11,"id": 11,"Gladiators":{"id":1,"name":"Gladiator 11","health":11,"strength":11},{"id":12,"name":"Gladiator 12","health":12,"strength":12}]} }
        [HttpPost]
        public async Task<IActionResult> CreateSchool(School school)
        {
            school.Id = (from g in schools
                         select g.Id).Max() + 1;
            school.PlayerID = (from g in schools
                               select g.PlayerID).Max() + 1;

            if(school.Gladiators != null)
            {
                foreach (Models.Gladiator y in school.Gladiators)
                {
                    foreach (School x in schools)
                    {
                        int a = x.Gladiators.FindIndex(g => g.Id == y.Id);
                        if (a > -1)
                        { return BadRequest(); }
                    }
                }
            }

            schools.Add(school);

            string jsonString = JsonConvert.SerializeObject(schools);

            return Ok(jsonString);
        }

        // json example {"name": "Ludus Magnus","playerID": 11,"id": 11}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSchool(int id, School school)
        {
            if (id < 1)
                return BadRequest();

            School? schoolToUpdate = schools.FirstOrDefault(g => g.Id == id);

            if (schoolToUpdate == null)
                return BadRequest();

            int index = schools.FindIndex(x => x.Id == id);

            schoolToUpdate.Name = school.Name;
            schoolToUpdate.PlayerID = school.PlayerID;
            foreach (Models.Gladiator x in school.Gladiators)
            {
                int ID = x.Id;
                foreach (School y in schools)
                {
                    int a = y.Gladiators.FindIndex(g => g.Id == ID);
                    if (a > -1)
                    { y.Gladiators.RemoveAt(a); }
                }
            }
            schoolToUpdate.Gladiators = school.Gladiators;
            schools[index] = schoolToUpdate;

            string jsonString = JsonConvert.SerializeObject(schools);

            return Ok(jsonString);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            if (id < 1)
                return BadRequest();

            int index = schools.FindIndex(x => x.Id == id);

            if (index == -1)
                return BadRequest();

            schools.RemoveAt(index);

            string jsonString = JsonConvert.SerializeObject(schools);

            return Ok(jsonString);
        }
    }
}

