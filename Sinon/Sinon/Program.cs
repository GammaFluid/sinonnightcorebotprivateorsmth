using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Sinon
{
    public class Program
    {
        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        private CommandHandler _handler;

        public async Task StartAsync()
        {
            

            _client = new DiscordSocketClient();

            new CommandHandler(_client);

            await _client.LoginAsync(TokenType.Bot, "MzUyMzgyODE0ODM1OTY1OTY0.DIgVlg.tzlOQPIoL1vc6Td8i8AwMobwYyI");

            await _client.StartAsync();

            _handler = new CommandHandler(_client);

            await Task.Delay(-1);
        }
    }
}
