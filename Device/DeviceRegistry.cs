using MILAV.Device.Newer;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace MILAV.Device
{
    public class DeviceRegistry
    {
        //public static Dictionary<string, Dictionary<string, CType>> manufacturerToModelToCType

        /// <summary>
        /// Slow
        /// </summary>
        public static void Initialize()
        {
            foreach (var type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()).Where(type => typeof(AbstractDevice).IsAssignableFrom(type) && !type.IsAbstract))
            {
                var groupField = type.GetField("group", BindingFlags.Static | BindingFlags.NonPublic);
                if (groupField != null && groupField.FieldType == typeof(string))
                {
                    var idField = type.GetField("id", BindingFlags.Static | BindingFlags.NonPublic);
                    if (idField != null && idField.FieldType == typeof(string))
                    {
                        var constructor = type.GetConstructor(new Type[0]);
                        if (constructor != null)
                        {
                            Debug.Print("FOUND DEVICE DEFINTION FOR: {0}:{1}", groupField.GetValue(null), idField.GetValue(null));
                            // do something awesome
                        }
                    }
                }
            }
        }
    }
}
