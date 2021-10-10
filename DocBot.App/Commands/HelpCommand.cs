using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace DocBot.App.Commands
{
    public class HelpCommand : CommandBase
    {
        [Command("help")]
        public async Task HandleCommandAsync()
        {
            await ReplyAsync($"**The following commands can be used:**{Environment.NewLine}" +
                             $"  • ping{Environment.NewLine}" +
                             $"  • konami{Environment.NewLine}" +
                             $"  • search \"your query\"");
        }
    }
}