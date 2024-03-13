using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Admin
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chatHub")
                .Build();
            await connection.StartAsync();
            while(true)
            {
                var message = Console.ReadLine();
                await connection.InvokeAsync("SendMessage",message);
            }
        
        }    
       
    }
    
}