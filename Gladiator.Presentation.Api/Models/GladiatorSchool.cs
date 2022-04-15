using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Gladiator.Presentation.Models
{
    public class School
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("playerID")]
        public int PlayerID { get; set; }
        [JsonProperty("gladiators")]
        public List<Gladiator> Gladiators { get; set; }
    }

}
