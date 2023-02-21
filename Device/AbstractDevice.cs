using MILAV.Data;
using Newtonsoft.Json;

namespace MILAV.Device
{
    public abstract class AbsractDevice<Config> where Config : AbstractDeviceConfig
    {
        public readonly Config config;

        private static readonly string group = "example_manufacturer";
        private static readonly string id = "example_model";

        public AbsractDevice(Config config)
        {
            this.config = config;
        }
    }

    public abstract class AbstractDeviceConfig
    {
        [JsonProperty]
        public readonly string type;                                     // REQUIRED
        [JsonProperty]
        public readonly string roomID;                                   // REQUIRED
        [JsonProperty]
        public readonly string key;                                      // REQUIRED
        [JsonProperty]
        public readonly string name;                                     // REQUIRED
        [JsonProperty]
        public readonly string manufacturer;                             // REQUIRED
        [JsonProperty]
        public readonly string model;                                    // REQUIRED

        [JsonProperty]
        public readonly string pdu;                                      // ! ACTUALLY USEFUL
        [JsonProperty]
        public readonly int pduOutlet;                                   // ! ACTUALLY USEFUL
    }

    public abstract class AbstractNetworkDeviceConfig : AbstractDeviceConfig
    {
        [JsonProperty]
        public readonly string protocol;
        [JsonProperty]
        public readonly string ip;
        [JsonProperty]
        public readonly int port;
    }

    public abstract class AbstractComPortDeviceConfig : AbstractDeviceConfig
    {
        [JsonProperty]
        public readonly string protocol;
        [JsonProperty]
        public readonly int baudRate;
        [JsonProperty]
        public readonly int dataBits;
        [JsonProperty]
        public readonly int stopBits;
        [JsonProperty]
        public readonly SerialParity parity;
    }

    public class TestDeviceConfig : AbstractNetworkDeviceConfig
    {

    }

    public class TestDevice : AbsractDevice<TestDeviceConfig>
    {
        public TestDevice(TestDeviceConfig config) : base(config)
        {

        }

        static void Test()
        {
            new TestDevice(new TestDeviceConfig());
        }
    }
}
