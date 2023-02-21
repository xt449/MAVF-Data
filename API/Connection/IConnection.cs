namespace MILAV.API.Connection
{
    public interface IConnection
    {
        bool Connect();

        byte[] ReadBytes(int maxLength);

        void WriteBytes(byte[] buffer, int offset, int length);
    }
}
