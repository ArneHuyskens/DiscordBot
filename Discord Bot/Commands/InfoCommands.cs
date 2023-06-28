using DSharpPlus;
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
    internal class InfoCommands : BaseCommandModule
    {
        [Command("help")]
        public async Task HelpCommand(CommandContext ctx)
        {
            var miscButton = new DiscordButtonComponent(ButtonStyle.Success, "miscButton", "Misc");
            var gameButton = new DiscordButtonComponent(ButtonStyle.Success, "gameButton", "Games");
            var infoButton = new DiscordButtonComponent(ButtonStyle.Success, "infoButton", "Info");

            var helpMessage = new DiscordMessageBuilder().AddEmbed(new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Black)
                .WithTitle("Help menu")
                .WithDescription("Want more info on the commands huh? Guess it can't be helped, just press the buttons...")
                )
                .AddComponents(miscButton, gameButton, infoButton);

            await ctx.Channel.SendMessageAsync(helpMessage);
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
    }
}
