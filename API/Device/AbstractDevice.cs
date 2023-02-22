using MILAV.API.Connection;
using MILAV.JSON;
using Newtonsoft.Json;

namespace MILAV.API.Device
{
    public abstract class AbstractDevice : IDevice
    {
        private static readonly string group = "example_manufacturer";
        private static readonly string id = "example_model";

        [JsonProperty]
        public readonly string type;                                     // REQUIRED
        [JsonProperty]
        public readonly string manufacturer;                             // REQUIRED
        [JsonProperty]
        public readonly string model;                                    // REQUIRED

        [JsonProperty("roomID")]
        public readonly string room;                                     // REQUIRED
        [JsonProperty]
        public readonly string key;                                      // REQUIRED
        [JsonProperty("name")]
        public readonly string displayName;                              // REQUIRED

        [JsonProperty]
        public readonly string pdu;                                      // ! ACTUALLY USEFUL
        [JsonProperty]
        public readonly int pduOutlet;                                   // ! ACTUALLY USEFUL

        [JsonProperty]
        [JsonConverter(typeof(IConnectionConverter))]
        public readonly IConnection communication;
    }
}
