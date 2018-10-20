using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackKline
{
    /// <summary>
    /// Use this class to manage how the bot should respond to messages.
    /// </summary>
    class MessageHandler
    {
        private SocketMessage discordMessage;
        private string BotName;
        private ConversationBot conversationBot;
        private CommandoBot JackCommandoBot;
        private CommandoBot MetatronCommandoBot;

        /// <summary>
        /// Creates a new instant of the MessageHandlerclass.
        /// </summary>
        public MessageHandler(string botName)
        {
            conversationBot = new ConversationBot();
            //JackCommandoBot = new CommandoBot();
            MetatronCommandoBot = new CommandoBot();
            BotName = botName;
        }

        /// <summary>
        /// The message the MessageHandler handles.
        /// </summary>
        public SocketMessage DiscordMessage
        {
            get => discordMessage;
            set
            {
                discordMessage = value;
            }
        }
        public async Task SetDiscordMessage(SocketMessage message)
        {
            DiscordMessage = message;
            await CheckMessage(DiscordMessage);
        }

        /// <summary>
        /// Checks if the bot should do anything in response to the message.
        /// </summary>
        /// <param name="message">The message that is checked.</param>
        private async Task CheckMessage(SocketMessage message)
        {
            ///To specify the commands for each bot, use the botname
            if (message.Content.ToCharArray().First() == '!')
            {
                //await JackCommandoBot.CheckCommando(message.Content, message, "Jack");
                await MetatronCommandoBot.CheckCommando(message.Content, message, "Metatron");
            }
            else if (message.Content.Split(' ').First() == "sprint")
            {
                //await JackCommandoBot.CheckCommando(message.Content, message, "Jack");
            }
            else
            {
                await conversationBot.Response(message.Content, message.Channel, BotName);
            }
        }




    }
}