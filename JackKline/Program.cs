using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace JackKline
{
	public class Program
	{
        //Create a new MessageHandler for each bot
        private MessageHandler JackMessageHandler;
        private MessageHandler MetatronMessageHandler;

        DiscordSocketClient client;
		public static void Main(string[] args)
			=> new Program().MainAsync().GetAwaiter().GetResult();

		public async Task MainAsync()
		{
			client = new DiscordSocketClient();
            
            //Put all bots in this Dictionary, using a name and token
            Dictionary<string, string> Tokens = new Dictionary<string, string>
            {
                {"Jack", "NDQwOTIwMDEwMzgzMTYzNDAy.DcpM5g.N-x6iRiSjFA6Kg75SJoBFsqOaaQ" },
                {"Metatron", "NDUwMTk3NDYwNzg3MjY1NTM3.DevulQ.iK0RdFKY_jxqOfrFoMwAtZWanWs" },

            };// Remember to keep this private!
            client.Log += Log;
			client.MessageReceived += MessageReceived;

            //Instantiate all the messagehandlers and log them in into the client
            //JackMessageHandler = new MessageHandler("Jack");
            //await client.LoginAsync(TokenType.Bot, Tokens["Jack"]);
            MetatronMessageHandler = new MessageHandler("Metatron");
            await client.LoginAsync(TokenType.Bot, Tokens["Metatron"]);
			
			await client.StartAsync();

			// Block this task until the program is closed.
			await Task.Delay(-1);
		}

		private Task Log(LogMessage msg)
		{
			Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
		}

		private async Task MessageReceived(SocketMessage message)
		{
            if(!message.Author.IsBot)
            {
                //Set the messages for all bots
                //await JackMessageHandler.SetDiscordMessage(message);

                await MetatronMessageHandler.SetDiscordMessage(message);

            }
        }
	}
}
