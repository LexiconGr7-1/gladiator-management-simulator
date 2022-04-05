using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gladiator.Presentation.Models
{
    public class Arena
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("schools")]
        public List<School> Schools { get; set; }
        [JsonProperty("gladiators")]
        public List<Models.Gladiator> Gladiators { get; set; }

    }
}
