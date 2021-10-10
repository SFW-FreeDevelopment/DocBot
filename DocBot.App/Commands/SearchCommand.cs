using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using Newtonsoft.Json.Linq;
using SerpApi;

namespace DocBot.App.Commands
{
    public class SearchCommand : CommandBase
    {
        [Command("search")]
        public async Task HandleCommandAsync([Remainder] string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                await ReplyAsync($"{Mention} This command requires a word or phrase to search for.");
                return;
            }
            
            var isExplicit = false;
            if (Program.BadWords?.Any() ?? false)
            {
                var lowerTopic = topic.ToLower();
                if (Program.BadWords.Any(word => lowerTopic.Contains(word)))
                {
                    isExplicit = true;
                }
            }
            if (isExplicit)
            {
                await ReplyAsync($"{Mention} This bot cannot be used to search for explicit content.");
                return;
            }

            Hashtable ht = new Hashtable
            {
                { "q", topic },
                { "hl", "en" },
                { "google_domain", "google.com" }
            };
            // TODO: Search Google
            var search = new GoogleSearch(ht, "dd89ccfbd61519dc8f7d3d1022ff0afa0facdc9afc18c285447bdee311843eeb");
            var data = search.GetJson();
            var results = (JArray)data["organic_results"];

            if (results == null || !results.Any())
            {
                await ReplyAsync($"{Mention} Your search for \"{topic}\" yielded no results.");
            }
            else
            {
                var result = results[0];
                var link = result["link"].ToString();
                await ReplyAsync($"{Mention} I found a result for \"{topic}\". Give this a look!{Environment.NewLine}{link}");
            }
        }
    }
}