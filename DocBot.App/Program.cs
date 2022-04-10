using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace DocBot.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BadWords = File.ReadAllLines(@$"{AppDomain.CurrentDomain.BaseDirectory}\Data\profanity.txt");
            }
            catch
            {
                BadWords = Array.Empty<string>();
            }

            RunBotAsync().GetAwaiter().GetResult();
            Console.ReadKey();
        }

        private static DiscordSocketClient _client;
        private static CommandService _commands;
        private static IServiceProvider _services;

        public static string[] BadWords;

        public static async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            string token = "ODk2NTQ5MTExMjMzMzkyNzAw.YWIubQ.9r4N2sn-6yyYu04HRbEvlGkCyzc";

            _client.Log += Log;

            await RegisterCommandsAsync();

            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private static Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }
        
        private static async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private static async Task HandleCommandAsync(SocketMessage socketMessage)
        {
            var message = socketMessage as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);
            if (message.Author.IsBot) return;

            int argPos = 0;
            if (message.HasStringPrefix("docbot ", ref argPos))
            {
                await Execute();
                return;
            }
            argPos = 0;
            if (message.HasStringPrefix("<@896549111233392700> ", ref argPos))
            {
                await Execute();
                return;
            }

            async Task Execute()
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
            }
        }
    }
}