using Discord_Bot.External_Classes;
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
    public class GamesCommands : BaseCommandModule
    {
        [Command("cardgame")]
        public async Task SimpleGame(CommandContext ctx)
        {
            var YourCard = new CardBuilder();
            var YourCardString = YourCard.SelectedCard.ToString();

            await ctx.Channel.SendMessageAsync("Drawing the cards...");

            var BotCard = new CardBuilder();
            var BotCardString = BotCard.SelectedCard.ToString();

            var message = new DiscordEmbedBuilder()
                    .WithTitle("Result")
                    .WithDescription("Let's see who won this game...")
                    .AddField("Your card", YourCardString)
                    .AddField("My card", BotCardString);

            if (YourCard.SelectedNumber > BotCard.SelectedNumber)
            {
                message.WithColor(DiscordColor.Green);
                message.AddField("Result", "Hm, it seems like you won...");
                   
            } else if (YourCard.SelectedNumber == BotCard.SelectedNumber)
            {
                message.WithColor(DiscordColor.Black);
                message.AddField("Result", "A draw huh, stop copying me...");
            } else
            { 
                message.WithColor(DiscordColor.Red);
                message.AddField("Result", "I won, this feeling of fulfillment is pretty good.");
            }

            await ctx.Channel.SendMessageAsync(message);
        }
    }
}
