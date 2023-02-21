using MILAV.Data;
using System;

namespace MILAV.Utilities
{
    public class SerialUtility
    {
        public static SerialParity FromString(string s)
        {
            Enum.TryParse(s, true, out SerialParity parity);
            return parity;
        }
    }
}
