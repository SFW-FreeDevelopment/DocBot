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
                             $"  • **ping** - Pings the Discord channel{Environment.NewLine}" +
                             $"  • **konami** - Displays the Konami code as emojis{Environment.NewLine}" +
                             $"  • **docs** - Lists helpful documentation links{Environment.NewLine}" +
                             $"  • **search** - Searches for the input query and posts the top result's link to chat");
        }
    }
}