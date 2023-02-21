using MILAV.Data;

namespace MILAV.Utilities
{
    public static class Extensions
    {
        public static string ToString(this SerialParity parity)
        {
            return parity.ToString().ToLower();
        }
    }
}
