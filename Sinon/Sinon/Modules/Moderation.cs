using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Used for ban commands
namespace Sinon.Modules
{
    public class Moderation : ModuleBase<SocketCommandContext>
    {
        [Command("ban")]
        [RequireContext(ContextType.Guild)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task BanAsync(IGuildUser user, [Remainder] string reason)
        {
            if (user == null) throw new ArgumentException("You need to mention a user in order to kick!\n \"$kick `user` `reason`");
            if (string.IsNullOrWhiteSpace(reason)) throw new ArgumentException("You need to provide a reason!\n \"$kick `user` `reason`");

            var allBans = await Context.Guild.GetBansAsync();
            bool isBanned = allBans.Select(b => b.User).Where(u => u.Username == user.Username).Any();

            if (!isBanned)
            {
                var targetHighest = (user as SocketGuildUser).Hierarchy;
                var senderHighest = (Context.User as SocketGuildUser).Hierarchy;

                if (targetHighest < senderHighest)
                {
                    await Context.Guild.AddBanAsync(user);

                    await Context.Channel.SendMessageAsync($"{Context.User.Mention} *has banned* ***{user.Mention}***. *Reason:* \"**{reason}**\"");

                    var dmChannel = await user.GetOrCreateDMChannelAsync();
                    await dmChannel.SendMessageAsync($"You have been banned from **{Context.Guild.Name}** for {reason}");
                }
            } 
        }
    }
}
