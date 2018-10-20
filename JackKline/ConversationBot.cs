

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace JackKline
{
    /// <summary>
    /// Use this class to programm the conversation for the bot.
    /// </summary>
    class ConversationBot
    {
        /// <summary>
        /// A dictionary with keywords to look up responses.
        /// </summary>
        private Dictionary<string, string> responseDictionary;
        private Dictionary<string, List<string>> JackResponses;
        private Dictionary<string, List<string>> MetatronResponses;


        /// <summary>
        /// Creates a new instant of the ConversationBotclass.
        /// </summary>
        public ConversationBot()
        {
            ///Create a new dictionary for each bot you want
            JackResponses = new Dictionary<string, List<string>>
            {
                {"nougat", new List<string>{"I like it. I like nougat"} },
                {"cocaine", new List<string>{"I like... cocaine."} },
                {"cowboys", new List<string>{"Dean *really* likes cowboys."} },
                {"Castiel", new List<string>{"...Father?"} },
                {"good night", new List<string>{"Sweet dreams!", "Sleep well!", "May your dreams be good.", "I don't sleep much...", "My father will watch over you."} },
                {"good morning", new List<string>{"I hope your dreams were happy :)", "Good morning!", "Did you sleep well?", "Mornin' Sunshine! I heard Dean say it once...", "Rise and shine!", "Hello."} },
                {"tentacle", new List<string>{"<:tentacle:440956627399606278>", "I'm still not sure... What is the difference between an octopus and a squid?",} }, // look up \:tentacle: in chat to see its ID, which is what Jack needs
                {"sex", new List<string>{"Seriously? Right in front of Sam's salad?",} },
                {"Lucifer", new List<string>{"My father is Castiel. Not Lucifer.",} },
                {"Kelly", new List<string>{"Mom?",} },
                {"hungry", new List<string>{"Does anyone here have nougat?", "I'd like some nougat...",} }, 

            
            };

            MetatronResponses = new Dictionary<string, List<string>>
            {
                {"Metatdouche", new List<string>{"What?", "Hey!",} },


            };
        }


        /// <summary>
        /// Gives a response to the given string on the given channel if available.
        /// </summary>
        /// <param name="responseString">The string that contains the words to respond to.</param>
        /// <param name="channel">The channel the response should be given to.</param>
        public async Task Response(string responseString, ISocketMessageChannel channel, string botName)
        {
            ///A list of strings that will be checked for keywords
            List<string> words = responseString.Split(' ').ToList();
            //Regex reg = new Regex(@"\w");
            ///Set the dictionary Responses to the dictionary with the corresponding name.
            ///For example: if the botname is Peter, Responses = PeterResponses
            Dictionary<string, List<string>> Responses = new Dictionary<string, List<string>>();
            if(botName == "Jack")
            {
                Responses = JackResponses;
            }
            if(botName == "Metatron")
            {
                Responses = MetatronResponses;

            }
            foreach (KeyValuePair<string, List<string>> key in JackResponses)

            {
                if (responseString.Contains(key.Key, StringComparison.OrdinalIgnoreCase))
                {
                    Random rnd = new Random();
                    if (JackResponses.TryGetValue(key.Key, out List<string> responses))
                    {
                        await channel.SendMessageAsync(responses[rnd.Next(responses.Count)]);
                    }
                }
            }

            foreach (KeyValuePair<string, List<string>> key in MetatronResponses)

            {
                if (responseString.Contains(key.Key, StringComparison.OrdinalIgnoreCase))
                {
                    Random rnd = new Random();
                    if (MetatronResponses.TryGetValue(key.Key, out List<string> responses))
                    {
                        await channel.SendMessageAsync(responses[rnd.Next(responses.Count)]);
                    }
                }

            }

            //Checks every string in the word list if it is inside the dictionary
            //If yes, it sends the response on the channel.

        }
        

    }
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}