using Discord.Commands;
using System.Threading.Tasks;

namespace Sinon.Modules
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        public async Task Testing()
        {
            await Context.Channel.SendMessageAsync("I am online");

        }

    }
}
