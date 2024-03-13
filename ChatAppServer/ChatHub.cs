using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ChatAppServer
{
    public class ChatHub : Hub
    {
        public async Task JoinChannel(string userId, string username)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");
            await Clients.Group($"user_{userId}").SendAsync("ReceiveMessage", $"**{username}** kanala katıldı!");
        }

        public async Task SendMessage( string message)
        {

            await Clients.All.SendAsync("ReceiveMessage", message);
         
        }


        public async Task SendPrivateMessage(string senderId, string receiverId, string message)
        {
            await Clients.Group($"user_{receiverId}").SendAsync("ReceivePrivateMessage", senderId, message);
        }


    }
}
