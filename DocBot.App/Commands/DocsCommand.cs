using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace DocBot.App.Commands
{
    public class DocsCommand : CommandBase
    {
        [Command("docs")]
        public async Task HandleCommandAsync()
        {
            await ReplyAsync($"**W3 Schools**{Environment.NewLine}" +
                             $"  • HTML - https://www.w3schools.com/tags/default.asp{Environment.NewLine}" +
                             $"  • CSS - https://www.w3schools.com/css/default.asp{Environment.NewLine}" +
                             $"  • JavaScript - https://www.w3schools.com/js/default.asp{Environment.NewLine}" +
                             $"  • SQL - https://www.w3schools.com/sql/default.asp{Environment.NewLine}" +
                             $"**Direct Sources**{Environment.NewLine}" +
                             $"  • C# - https://docs.microsoft.com/en-us/dotnet/api/?view=netcore-3.1");
        }
    }
}