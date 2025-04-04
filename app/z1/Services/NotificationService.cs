using System.IO.MemoryMappedFiles;
using System.Text;

namespace z1.Services
{
    public class NotificationService
    {
        private const string MapName = "HomeworkNotifications";

        public void SendNotification(string message)
        {
            using var mmf = MemoryMappedFile.CreateOrOpen(MapName, 1024);
            using var accessor = mmf.CreateViewAccessor();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            accessor.WriteArray(0, buffer, 0, buffer.Length);
        }

        public string ReceiveNotification()
        {
            try
            {
                using var mmf = MemoryMappedFile.OpenExisting(MapName);
                using var accessor = mmf.CreateViewAccessor();
                byte[] buffer = new byte[1024];
                accessor.ReadArray(0, buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer).TrimEnd('\0');
            }
            catch
            {
                return null;
            }
        }
    }
}