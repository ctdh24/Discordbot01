using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot01
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new DiscordClient();
            bot.MessageReceived += Bot_MessageReceived;
            bot.Connect("discord.bot.tutorial@gmail.com","september24");
            bot.Wait();
        }

        private static void Bot_MessageReceived(object sender, MessageEventArgs e)
        {
            Console.WriteLine("{0} said: {1}", e.User.Name, e.Message.Text);
        }
    }
}
