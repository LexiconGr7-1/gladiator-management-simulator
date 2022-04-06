using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Gladiator.Presentation.Models
{
    public class Gladiator
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("health")]
        public double Health { get; set; }
        [JsonProperty("strength")]
        public double Strength { get; set; }
    }
}
