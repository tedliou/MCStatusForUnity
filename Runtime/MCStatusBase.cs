using Newtonsoft.Json;

namespace VerveCode
{
    public abstract class MCStatusBase
    {
        [JsonProperty("online")]
        public bool Online { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("eula_blocked")]
        public bool EulaBlocked { get; set; }

        [JsonProperty("retrieved_at")]
        public long RetrievedAt { get; set; }

        [JsonProperty("expires_at")]
        public long ExpiresAt { get; set; }

        [JsonProperty("motd")]
        public Motd Motd { get; set; }
    }

    public class Motd
    {
        [JsonProperty("raw")]
        public string Raw { get; set; }

        [JsonProperty("clean")]
        public string Clean { get; set; }

        [JsonProperty("html")]
        public string HTML { get; set; }
    }
}
