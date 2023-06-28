using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
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
        [Cooldown(3, 30, CooldownBucketType.User)]
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

        [Command("poll")]
        [RequirePermissions(Permissions.ManageMessages)]
        public async Task PollCommand(CommandContext ctx, int TimeLimit, string o1, string o2, string o3, string o4, params string[] question)
        {
            var interactivity = ctx.Client.GetInteractivity();
            TimeSpan timer = TimeSpan.FromSeconds(TimeLimit);
            DiscordEmoji[] emojis =
                {
                    DiscordEmoji.FromName(ctx.Client, ":one:", false),
                    DiscordEmoji.FromName(ctx.Client, ":two:", false),
                    DiscordEmoji.FromName(ctx.Client, ":three:", false),
                    DiscordEmoji.FromName(ctx.Client, ":four:", false)
                };

            string optionsString = emojis[0] + ": " + o1 + "\n" +
                                   emojis[1] + ": " + o2 + "\n" +
                                   emojis[2] + ": " + o3 + "\n" +
                                   emojis[3] + ": " + o4;

            var pollMessage = new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Black)
                .WithTitle(string.Join(" ", question))
                .WithDescription(optionsString);

            var putReactOn = await ctx.Channel.SendMessageAsync(pollMessage);

            foreach (var emoji in emojis)
            {
                await putReactOn.CreateReactionAsync(emoji);
            }

            var result = await interactivity.CollectReactionsAsync(putReactOn, timer);

            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;

            foreach (var emoji in result)
            {
                if (emoji.Emoji == emojis[0])
                {
                    count1++;
                }
                if (emoji.Emoji == emojis[1])
                {
                    count2++;
                }
                if (emoji.Emoji == emojis[2])
                {
                    count3++;
                }
                if (emoji.Emoji == emojis[3])
                {
                    count4++;
                }
            }

            int totalVotes = count1 + count2 + count3 + count4;

            var resultString = o1 + ": " + count1 + " votes \n" +
                               o2 + ": " + count2 + " votes \n" +
                               o3 + ": " + count3 + " votes \n" +
                               o4 + ": " + count4 + " votes \n\n" +
                               "Total number of votes: " + totalVotes;

            var resultMessage = new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Green)
                .WithTitle("Results of poll: " + string.Join(" ", question))
                .WithDescription(resultString);

            await ctx.Channel.SendMessageAsync(resultMessage);
        }

        [Command("button")]
        public async Task ButtonCommand(CommandContext ctx)
        {
            DiscordButtonComponent button1 = new DiscordButtonComponent(ButtonStyle.Primary, "1", "Button 1");
            DiscordButtonComponent button2 = new DiscordButtonComponent(ButtonStyle.Primary, "2", "Button 2");

            var message = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Black)
                .WithTitle("This is a message with buttons")
                .WithDescription("Please select a button")
                )
                .AddComponents(button1)
                .AddComponents(button2);

            await ctx.Channel.SendMessageAsync(message);
        }
    }
}
