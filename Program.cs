using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace CleanDiscordBot
{
    class Program
    {
        public DiscordSocketClient Client;
        Handler handler;
        static void Main() => new Program().StartBot();
        public void StartBot()
        {
            //Log.Info("Starting bot...");
            Client = new DiscordSocketClient();
            Client.MessageReceived += HandleMsg;
            Client.LoginAsync(TokenType.Bot, "TOKEN");
            Client.StartAsync();
            handler = new Handler(this);
            //Log.Info("Bot Started successfully.");
            while (true) ;
        }

        async Task HandleMsg(SocketMessage msg)
        {
            handler.HandleMsg(msg);
        }

    }
    static class Log
    {
        public static void Info<T>(T args)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{DateTime.Now.TimeOfDay}]: {args}");
        }
    }
}
