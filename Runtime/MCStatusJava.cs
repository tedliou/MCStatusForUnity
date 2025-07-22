using Newtonsoft.Json;
using System.Collections.Generic;

namespace VerveCode
{
    public class MCStatusJava : MCStatusBase
    {
        [JsonProperty("version")]
        public VersionJava Version { get; set; }

        [JsonProperty("players")]
        public PlayersJava Players { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("mods")]
        public List<ModJava> Mods { get; set; }

        [JsonProperty("software")]
        public string Software { get; set; }

        [JsonProperty("plugins")]
        public List<PluginJava> Plugins { get; set; }

        [JsonProperty("srv_record")]
        public SrvRecordJava SrvRecord { get; set; }
    }

    public class VersionJava
    {
        [JsonProperty("name_raw")]
        public string NameRaw { get; set; }

        [JsonProperty("name_clean")]
        public string NameClean { get; set; }

        [JsonProperty("name_html")]
        public string NameHTML { get; set; }

        [JsonProperty("protocol")]
        public int Protocol { get; set; }
    }

    public class PlayersJava
    {
        [JsonProperty("online")]
        public int Online { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("list")]
        public List<PlayerJava> List { get; set; }
    }

    public class PlayerJava
    {
        [JsonProperty("uuid")]
        public string UUID { get; set; }

        [JsonProperty("name_raw")]
        public string NameRaw { get; set; }

        [JsonProperty("name_clean")]
        public string NameClean { get; set; }

        [JsonProperty("name_html")]
        public string NameHTML { get; set; }
    }

    public class ModJava
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class PluginJava
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class SrvRecordJava
    {
        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }
    }
}
