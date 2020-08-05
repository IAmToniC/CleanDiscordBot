using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace CleanDiscordBot
{
    public abstract class Command
    {
        public virtual string Comm() => "!command";
        public virtual void Execute(string args, SocketCommandContext context)
        {

        }
        public void Reply(string args, SocketCommandContext context) => context.Message.Channel.SendMessageAsync(args);
        public void ReplyDm(string args, SocketUser user) => user.SendMessageAsync(args);
    }
    public class Ping : Command //testing
    {
        public override string Comm() => "!ping";
        public override void Execute(string args, SocketCommandContext context)
        {
            Reply("pong xD", context);
        }
    }
    public class Reply : Command //testing Parameters xD
    {
        public override string Comm() => "!reply";

        public override void Execute(string args, SocketCommandContext context)
        {
            Reply(args.Replace("@everyone", " ").Replace("@here", " "), context);
        }

    }
}
