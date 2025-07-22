using Newtonsoft.Json;

namespace VerveCode
{
    public class MCStatusBedrock : MCStatusBase
    {
        [JsonProperty("version")]
        public VersionBedrock Version { get; set; }

        [JsonProperty("players")]
        public PlayersBedrock Players { get; set; }

        [JsonProperty("gamemode")]
        public string Gamemode { get; set; }

        [JsonProperty("server_id")]
        public string ServerId { get; set; }

        [JsonProperty("edition")]
        public string Edition { get; set; }
    }

    public class VersionBedrock
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("protocol")]
        public int? Protocol { get; set; }
    }

    public class PlayersBedrock
    {
        [JsonProperty("online")]
        public int? Online { get; set; }

        [JsonProperty("max")]
        public int? Max { get; set; }
    }
}
