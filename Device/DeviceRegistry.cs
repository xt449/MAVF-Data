using MILAV.API.Device;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MILAV.Device
{
    public class DeviceRegistry
    {
        private static Dictionary<(DeviceType, string), Type> deviceTypeAndIdToType;

        /// <summary>
        /// Slow
        /// </summary>
        public static void Initialize()
        {
            foreach (var type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(type => typeof(IDevice).IsAssignableFrom(type) && !type.IsAbstract))
            {
                var attribute = (DeviceAttribute) Attribute.GetCustomAttribute(type, typeof(DeviceAttribute));
                if (attribute != null)
                {
                    // This is probably not necessary
                    if (type.GetConstructor(new Type[0]) != null)
                    {
                        Debug.Print("FOUND '{0}' DEVICE DEFINTION FOR ID: '{1}'", attribute.type, attribute.id);
                        deviceTypeAndIdToType.Add((attribute.type, attribute.id), type);
                    }
                }
            }
        }
    }
}
