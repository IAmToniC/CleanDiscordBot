using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace CleanDiscordBot
{
    class Handler
    {
        public Dictionary<string, Command> Comms = new Dictionary<string, Command>();
        Program _program;
        public Handler(Program prgm)
        {
            _program = prgm;
            foreach (var type in Assembly.GetAssembly(typeof(Command)).GetTypes().Where(_ => _.IsClass && !_.IsAbstract && _.IsSubclassOf(typeof(Command))))
            {
                var cmd = (Command)Activator.CreateInstance(type);
                Comms.Add(cmd.Comm(), cmd);
            }
        }
        public void HandleMsg(SocketMessage message)
        {
            if (message.Author.IsBot) return;
            foreach (string thing in Comms.Keys.Where(_ => message.Content.StartsWith(_)))
            {
                Log.Info("Handling a command...");
                SocketUserMessage msg = message as SocketUserMessage;
                new Task(() => Comms[thing].Execute(message.Content.Replace(thing + " ", ""), new SocketCommandContext(_program.Client, msg))).Start();
            }
        }
    }
}
