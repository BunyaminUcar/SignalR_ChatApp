using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ChatAppClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chatHub")
                .Build();

            await connection.StartAsync();

            Console.Write("Kullanıcı kimliğinizi girin: ");
            var userId = Console.ReadLine();
            Console.Write("Kullanıcı adınızı girin: ");
            var username = Console.ReadLine();

            await connection.InvokeAsync("JoinChannel", userId, username);

            // Güncellemeler: Özel mesajlaşma için eklenenler
            connection.On<string, string>("ReceivePrivateMessage", (senderId, message) =>
            {
                Console.WriteLine($"{senderId} tarafından özel mesaj: {message}");
            });

            connection.On<string>("ReceiveMessage", (message) =>
            {
                Console.WriteLine(message);
            });
            Console.WriteLine("Alıcı ID: ");
                                var receiverId = Console.ReadLine();

            while (true)
            {
                
                    
                    Console.WriteLine("Mesaj: ");
                    var message = Console.ReadLine();
                    await connection.InvokeAsync("SendPrivateMessage", userId, receiverId, message);
 
            }
        }
    }
}


