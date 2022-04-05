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
        public List<Gladiator> Gladiators
            => Schools.SelectMany(s => s.Gladiators).ToList();

    }
}
