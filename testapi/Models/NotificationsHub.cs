using Microsoft.AspNetCore.SignalR;
namespace testapi.Models
{

    public class NotificationsHub :Hub
    {
        public override async Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;

            Console.WriteLine($"--> Połączono klienta: {connectionId}");

            await Clients.Caller.SendAsync("ReceiveMessage", "Serwer", "Połączono pomyślnie z API!");

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"--> Rozłączono klienta: {Context.ConnectionId}");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
