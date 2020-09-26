using DSharpPlus;
using System;
using System.Security.Principal;
using System.Threading.Tasks;

namespace FlavDSharp
{
    partial class Program
    {
        static DiscordClient discord;
        static void Main(String[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();

        }

        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = Creds.token,
                TokenType = TokenType.Bot
            });

            discord.MessageCreated += async e =>
            {
                if(e.Message.ChannelId.Equals(614206030372667396) & e.Message.Content.StartsWith("ping"))
                {
                    await e.Message.RespondAsync("pong!");
                }
                else if(e.Message.Content.Equals("RAWR"))
                {
                    await e.Message.RespondAsync("RAWR!!!");
                }

            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
