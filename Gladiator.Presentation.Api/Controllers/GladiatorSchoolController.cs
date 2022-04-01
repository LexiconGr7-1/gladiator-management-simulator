using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : ControllerBase
    {
        public class School
        {
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("playerID")]
            public int PlayerID { get; set; }
             
        }
       
        private readonly List<School> schools = new()
        {
            new School
            {
                Name = "School 1",
                Id = 1,
                PlayerID = 1,
                
            },
            new School
            {
                Name = "School 2",
                Id = 2,
                PlayerID = 2,

            },
            new School
            {
                Name = "School 3",
                Id = 3,
                PlayerID = 3,

            },
            new School
            {
                Name = "School 4",
                Id = 4,
                PlayerID = 4,

            },
            new School
            {
                Name = "School 5",
                Id = 5,
                PlayerID = 5,

            },
            new School
            {
                Name = "School 6",
                Id = 6,
                PlayerID = 6,

            },
            new School
            {
                Name = "School 7",
                Id = 7,
                PlayerID = 7,

            },
            new School
            {
                Name = "School 8",
                Id = 8,
                PlayerID = 8,

            },
            new School
            {
                Name = "School 9",
                Id = 9,
                PlayerID = 9,

            },
            new School
            {
                Name = "School 10",
                Id = 10,
                PlayerID = 10,

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


        // json example {"name": "Ludus Magnus","playerID": 11,"id": 11}
        [HttpPost]
        public async Task<IActionResult> CreateSchool(School school)
        {
            school.Id = (from g in schools
                            select g.Id).Max() + 1;
            school.PlayerID = (from g in schools
                         select g.PlayerID).Max() + 1;
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

