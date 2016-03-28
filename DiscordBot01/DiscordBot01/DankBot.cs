using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot01
{
    public class DankBot
    {
        private DiscordClient bot;
        //DankBot's constructor
        public DankBot()
        {
            bot = new DiscordClient();
            bot.MessageReceived += Bot_MessageReceived;
            bot.Connect("discord.bot.tutorial@gmail.com", "september24");
            bot.Wait();
        }

        private static void Bot_MessageReceived(object sender, MessageEventArgs e)
        {
            Console.WriteLine("{0} in {1} said: {2}", e.User.Name, e.Channel ,e.Message.Text);
            if (e.Message.IsAuthor) return;
            if (e.Message.Text == "1d6")
            {
                Random diceroll = new Random();
                int diceresult = diceroll.Next(1, 7);
                e.Channel.SendMessage(e.User.Mention + " rolled a " + diceresult);
            }
            if (e.Message.Text == "1d20")
            {
                Random diceroll = new Random();
                int diceresult = diceroll.Next(1, 21);
                e.Channel.SendMessage(e.User.Mention + " rolled a " + diceresult);
            }
            if (e.Message.Text == "1d100")
            {
                Random diceroll = new Random();
                int diceresult = diceroll.Next(1, 101);
                e.Channel.SendMessage(e.User.Mention + " rolled a " + diceresult);
            }

        }
    }
}
