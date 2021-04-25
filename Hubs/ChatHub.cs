using System.Threading.Tasks;
using ExampleIntermediateChatSignalR.Models;
using ExampleIntermediateChatSignalR.Repository;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace ExampleIntermediateChatSignalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionRepository _connection = new ConnectionRepository();

        public ChatHub()
        {
            
        }

        public override Task OnConnectedAsync()
        {
            var userContext = Context.GetHttpContext().Request.Query["user"];
            var user = JsonConvert.DeserializeObject<User>(userContext);
            _connection.Add(Context.ConnectionId, user);
            Clients.All.SendAsync("chat", _connection.GetUsers(), user);
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(ChatMessage chatMessage)
        {
            await Clients.Client(_connection.GetUserId(chatMessage.Destination)).SendAsync("Receive", chatMessage.Sender, chatMessage.Message);
        }

        /*public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("Receive", user, message);
        }*/
    }
}