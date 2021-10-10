using System.Threading.Tasks;
using Discord.Commands;

namespace DocBot.App.Commands
{
    public class KonamiCommand : CommandBase
    {
        [Command("konami")]
        public async Task HandleCommandAsync()
        {
            await ReplyAsync("⬆⬆⬇⬇⬅➡⬅➡🅱🅰");
        }
    }
}