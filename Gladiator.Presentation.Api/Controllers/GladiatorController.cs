using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;

using Newtonsoft.Json;
namespace Gladiator.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class GladiatorController : ControllerBase
    {
        public class Gladiator : GladiatorController
        {
            public double Health { get; set; }

            public int ID { get; set; }
            public string Name { get; set; }

            public Double Strength { get; set; }

        }
        [NonAction]
        public List<Gladiator> Glads() {
            Gladiator gladiator1 = new Gladiator();
            gladiator1.Name = "gladiator1";
            gladiator1.ID = 1;
            gladiator1.Strength = 1;

            Gladiator gladiator2 = new Gladiator();
            gladiator2.Name = "gladiator2";
            gladiator2.ID = 2;
            gladiator2.Strength = 2;

            Gladiator gladiator3 = new Gladiator();
            gladiator3.Name = "gladiator3";
            gladiator3.ID = 3;
            gladiator3.Strength = 3;

            Gladiator gladiator4 = new Gladiator();
            gladiator4.Name = "gladiator4";
            gladiator4.ID = 4;
            gladiator4.Strength = 4;

            Gladiator gladiator5 = new Gladiator();
            gladiator5.Name = "gladiator5";
            gladiator5.ID = 5;
            gladiator5.Strength = 5;

            Gladiator gladiator6 = new Gladiator();
            gladiator6.Name = "gladiator6";
            gladiator6.ID = 6;
            gladiator6.Strength = 6;

            Gladiator gladiator7 = new Gladiator();
            gladiator7.Name = "gladiator7";
            gladiator7.ID = 7;
            gladiator7.Strength = 7;

            Gladiator gladiator8 = new Gladiator();
            gladiator8.Name = "gladiator8";
            gladiator8.ID = 8;
            gladiator8.Strength = 8;

            Gladiator gladiator9 = new Gladiator();
            gladiator9.Name = "gladiator9";
            gladiator9.ID = 9;
            gladiator9.Strength = 9;

            Gladiator gladiator10 = new Gladiator();
            gladiator10.Name = "gladiator10";
            gladiator10.ID = 10;
            gladiator10.Strength = 10;

            List<Gladiator> gladiators = new List<Gladiator>();
            gladiators.Add(gladiator1);
            gladiators.Add(gladiator2);
            gladiators.Add(gladiator3);
            gladiators.Add(gladiator4);
            gladiators.Add(gladiator5);
            gladiators.Add(gladiator6);
            gladiators.Add(gladiator7);
            gladiators.Add(gladiator8);
            gladiators.Add(gladiator9);
            gladiators.Add(gladiator10);
            return gladiators;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGladiator(int id)
        {
            if (id < 1)
                return BadRequest();
            List<Gladiator> gladiators = Glads();
            
            Gladiator gladiator =gladiators.Find(x => x.ID==id);
            string jsonString = JsonConvert.SerializeObject(gladiator);
            return Ok(jsonString);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetGladiators()
        {
            List < Gladiator > gladiators= Glads();
            string jsonString = JsonConvert.SerializeObject(gladiators);
            return Ok(jsonString);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGladiator(Gladiator gladiator)
        {
            if (gladiator == null)
                return BadRequest();
            gladiator.ID = 100;
            gladiator.Name = "Brutus";
            gladiator.Health = 100;
            gladiator.Strength = 100;
            
            string jsonString = JsonConvert.SerializeObject(gladiator);
            return Ok(jsonString);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGladiator(int id, Gladiator gladiator)
        {
            if (gladiator == null || id < 1)
                return BadRequest();
            gladiator.ID = id;
            string jsonString = JsonConvert.SerializeObject(gladiator);
            return Ok(jsonString); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGladiator(int id)
        {
            if (id < 1)
                return BadRequest();
            List<Gladiator> gladiators = Glads();
            int I = gladiators.FindIndex(x => x.ID == id);
            gladiators.RemoveAt(I);
            string jsonString = JsonConvert.SerializeObject(gladiators);
            return Ok(jsonString);
        }
            }
}

    

