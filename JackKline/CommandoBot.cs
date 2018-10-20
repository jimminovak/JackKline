using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace JackKline
{
    class CommandoBot
    {
        private string Botname;
        private bool done;
        private Timer timmyTimer;
        public CommandoBot()
        {

        }

        public async Task CheckCommando(string commando, SocketMessage message, string botName)
        {
            Botname = botName;

            if (commando == "!schedule")
            {
                if (botName == "Jack")
                {
                    await message.Channel.SendMessageAsync("```31 May 2018: first writer check -in \n24 June 2018: second writer check -in, " +
                                                               "rough drafts of at least 50 % completion due \n24 July 2018: final drafts due```");
                }
            }
            else if (commando.Split(' ').First() == "sprint")
            {
                await SetTimer(commando, message);
            }
        }

        public async Task SetTimer(string commando, SocketMessage message)
        {

            if (Int32.TryParse(commando.Split(' ').Last(), out int timmyTime))
            {
                await TimerMessageOne(message, timmyTime);
                timmyTimer = new Timer(timmyTime * 60000);
                timmyTimer.Elapsed += (sender, e) => TimmyTick(sender, e, message);
                timmyTimer.Start();
            }
        }

        private async Task TimmyTick(object sender, ElapsedEventArgs e, SocketMessage message)
        {
            timmyTimer.Stop();
            await TimerMessageTwo(message);
        }

        public async Task TimerMessageOne(SocketMessage message, int timmyTime)
        {
            await message.Channel.SendMessageAsync(message.Author.Mention + ", I started a timer for " + timmyTime + " minutes.");
        }

        public async Task TimerMessageTwo(SocketMessage message)
        {
            await message.Channel.SendMessageAsync("Hey " + message.Author.Mention + "! Ding dong! Time's up!");
        }


    }
}
