using DSharpPlus;
using System;
using System.Security.Principal;
using System.Threading.Tasks;

namespace FlavDSharp
{
    partial class FlavDSharpBot
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
                string[] commands = {
                                    "!ping","RAWR","!website","!twitch",
                                    "!github","!patreon",
                                    "!streamwarriors","!legionslive",

                                    "!commands"
                                    };

                string[] answers = {
                                    "pong!","RAWR!!!","https://www.flavcreations.com/","https://www.twitch.tv/flavcreations",
                                    "https://www.github.com/Flavius-The-Person","",
                                    "https://www.github.com/Flavius-The-Person/stream-warriors-engine","Legions Live Game Coming Soon!",
                                    
                                    "!ping, RAWR, !website, !twitch, !github, !streamwarriors, !legionslive"
                                    };
                
                for(int x = 0; x < commands.Length; x++)
                {
                    if(e.Message.Content.Equals(commands[x]))
                    {
                        await e.Message.RespondAsync(answers[x]);
                    }
                }
                
                /*
                if(e.Message.ChannelId.Equals(614206030372667396) & e.Message.Content.StartsWith(commands[0]))
                {
                    await e.Message.RespondAsync("pong!");
                }
                else if(e.Message.Content.Equals(commands[1]))
                {
                    await e.Message.RespondAsync("RAWR!!!");
                }
                else if (e.Message.Content.Equals(commands[2]))
                {
                    await e.Message.RespondAsync("https://www.flavcreations.com/");
                }
                else if (e.Message.Content.Equals("!twitch"))
                {
                    await e.Message.RespondAsync("https://www.twitch.tv/flavcreations");
                }
                else if (e.Message.Content.Equals("!github"))
                {
                    await e.Message.RespondAsync("https://github.com/Flavius-The-Person");
                }
                else if (e.Message.Content.Equals("!patreon"))
                {
                    await e.Message.RespondAsync("");
                }
                else if (e.Message.Content.Equals("!streamwarriors"))
                {
                    await e.Message.RespondAsync("https://github.com/Flavius-The-Person/stream-warriors-engine");
                }
                else if (e.Message.Content.Equals("!legionslive"))
                {
                    await e.Message.RespondAsync("Legions Live Game Coming Soon!");
                }*/
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
