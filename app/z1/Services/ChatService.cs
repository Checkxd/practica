using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace z1.Services
{
    public class ChatService
    {
        public async Task SendMessageAsync(string message)
        {
            using var pipeClient = new NamedPipeClientStream(".", "JournalChatPipe", PipeDirection.Out);
            await pipeClient.ConnectAsync();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            await pipeClient.WriteAsync(buffer, 0, buffer.Length);
        }

        public async Task<string> ReceiveMessageAsync()
        {
            using var pipeServer = new NamedPipeServerStream("JournalChatPipe", PipeDirection.In);
            await pipeServer.WaitForConnectionAsync();
            byte[] buffer = new byte[1024];
            int bytesRead = await pipeServer.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }
    }
}