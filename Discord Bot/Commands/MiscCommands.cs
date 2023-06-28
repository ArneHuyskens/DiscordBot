using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bot.Commands
{
    public class MiscCommands : BaseCommandModule
    {
        [Command("summon")]
        public async Task TestCommand(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Servant, Avenger. Summoned upon your request....What's with that look? Come on, here's the contract.");
        }

        [Command("add")]
        public async Task Addition(CommandContext ctx, int n1, int n2)
        {
            int answer = n1 + n2;
            await ctx.Channel.SendMessageAsync(answer.ToString());
        }

        [Command("subtract")]
        public async Task Subtract(CommandContext ctx, int n1, int n2)
        {
            int answer = n1 - n2;
            await ctx.Channel.SendMessageAsync(answer.ToString());
        }

        [Command("ping")]
        public async Task Ping(CommandContext ctx)
        {
            var startTime = ctx.Message.CreationTimestamp.UtcDateTime;
            var latency = DateTime.UtcNow - startTime;
            var rounded = Math.Round(latency.TotalSeconds, 2);

            var response = $"Hm, what's this? You're expecting me to say pong? How annoying, Pong! This is how long it took: {rounded} seconds";
            await ctx.Channel.SendMessageAsync(response);
        }

        [Command("info")]
        public async Task Info(CommandContext ctx)
        {
            var embedMessage = new DiscordEmbedBuilder()
                .WithTitle("My website")
                .WithUrl("https://arnehuyskens.sinners.be")
                .WithDescription("This is a message with more info about my creator.")
                .WithColor(DiscordColor.Black)
                .AddField("Who am I", "My name is Arne Huyskens and I made this bot to learn more about programming in c#/.net")
                .WithImageUrl("https://images.alphacoders.com/102/thumb-1920-1025065.png")
                .WithFooter("Made by Arne Huyskens, Husky6666")
                .WithTimestamp(DateTimeOffset.UtcNow);

            await ctx.Channel.SendMessageAsync(embedMessage);
        }
    }
}
