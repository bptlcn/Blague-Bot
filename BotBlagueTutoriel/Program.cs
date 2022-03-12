using DSharpPlus;
using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace Tutorial;

static class Program
{
    static void Main(string[] args)
    {
        MainAsync().GetAwaiter().GetResult();
    }

    
    static async Task MainAsync()
    {
        var discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = "Your Token !",
            TokenType = TokenType.Bot
        });

        var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
        { 
            StringPrefixes = new[] { "!" }
        });

        commands.RegisterCommands<Commands>();

        await discord.ConnectAsync();
        await Task.Delay(-1);
    }
}
