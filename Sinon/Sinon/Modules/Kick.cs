using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sinon.Modules
{
    public class Kick : ModuleBase<SocketCommandContext>
    {
        [Command("kick")]
        [RequireBotPermission(GuildPermission.KickMembers)]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public  async Task KickAsync(SocketGuildUser user, [Remainder] string reason)
        {
            if (user == null) throw new ArgumentException("You need to mention a user in order to kick!\n \"$kick `user` `reason`");
            if (string.IsNullOrWhiteSpace(reason)) throw new ArgumentException("You need to provide a reason!\n \"$kick `user` `reason`");
            {
                var targetHighest = (user as SocketGuildUser).Hierarchy;
                var senderHighest = (Context.User as SocketGuildUser).Hierarchy;

                if (targetHighest < senderHighest);
                {
                    await Context.Channel.SendMessageAsync($"{Context.User.Mention} *has kicked* {user.Mention}. *Reason:* \"**{reason}**\"");
                    await user.KickAsync();
                }
            }
        }
    }
}
