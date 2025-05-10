using System.Collections.Generic;
using Newtonsoft.Json;

namespace TareaDeAPI.Models
{
    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }  // Agregué la propiedad Weight

        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }

        [JsonProperty("stats")]
        public List<StatInfo> Stats { get; set; }

        [JsonProperty("types")]  // Mapeo la lista de tipos
        public List<TypeInfo> Types { get; set; }
    }

    public class Sprites
    {
        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }
    }

    public class StatInfo
    {
        [JsonProperty("stat")]
        public Stat Stat { get; set; }

        [JsonProperty("base_stat")]
        public int BaseStat { get; set; }
    }

    public class Stat
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class TypeInfo
    {
        [JsonProperty("type")]
        public TypeDetail Type { get; set; }
    }

    public class TypeDetail
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}