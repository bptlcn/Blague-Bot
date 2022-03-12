using System.Diagnostics.Metrics;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using Tutorial.Blague;
using DSharpPlus.CommandsNext.Attributes;
using Newtonsoft.Json;
using Newtonsoft;

namespace Tutorial;

public class Commands : BaseCommandModule
{
    private HttpClient _client;
    
    public async Task<string> GetBlague()
    {
        var stock = string.Empty;
        var response = _client.GetAsync("https://blague.xyz/api/joke/random");

        if (response.Result.IsSuccessStatusCode)
        {
            stock = await response.GetAwaiter().GetResult().Content.ReadAsStringAsync();
        }

        return stock;
    }
    
    [Command("blague")]
    public async Task Blague(CommandContext ctx)
    {
        _client = new HttpClient();

        var blague = JsonConvert.DeserializeObject<Root>(GetBlague().GetAwaiter().GetResult());
        
        await ctx.Channel.SendMessageAsync($"{blague.Joke.Question}");
        
        Thread.Sleep(5000);

        await ctx.Channel.SendMessageAsync($"{blague.Joke.Answer} :joy:");

    }
}