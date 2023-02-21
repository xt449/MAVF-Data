using MILAV.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace MILAV.Device.Newer
{
    public abstract class AbstractDevice
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
        public readonly JObject communicationProperties;

        [JsonIgnore]
        private AbstractCommunication communication;

        [JsonIgnore]
        public AbstractCommunication Communication
        {
            get
            {
                if (communication == null)
                {
                    communication = SetupCommunication();
                    // TODO : GC -> communicationProperties = null;
                }
                return communication;
            }
        }

        protected abstract AbstractCommunication SetupCommunication();
    }

    public abstract class AbstractCommunication
    {
        [JsonProperty]
        public readonly string type;

        public abstract bool IsConnected();

        public abstract void Connect();

        public abstract void Disconnect();

        public abstract void SendText(string data);

        public abstract void SendBytes(byte[] bytes);

        public abstract void ProcessData();
    }

    public class SerialCommunication : AbstractCommunication
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

        public override void Connect()
        {
            throw new NotImplementedException();
        }

        public override void Disconnect()
        {
            throw new NotImplementedException();
        }

        public override bool IsConnected()
        {
            throw new NotImplementedException();
        }

        public override void ProcessData()
        {
            throw new NotImplementedException();
        }

        public override void SendBytes(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public override void SendText(string data)
        {
            throw new NotImplementedException();
        }
    }
}
