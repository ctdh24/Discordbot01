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
            //dice rolls
            if (e.Message.Text.Contains("1d") && e.Channel.Name == "dice-check")
            {
                Random diceroll = new Random();
                int temp = e.Message.Text.IndexOf("d");
                int dice;
                try {
                    dice = Int32.Parse(e.Message.Text.Substring(temp + 1));
                }
                catch {
                    e.Channel.SendMessage(e.User.Mention + ": Incorrect format");
                    return;
                }
                int diceresult = diceroll.Next(1, dice);
                e.Channel.SendMessage(e.User.Mention + " rolled a " + diceresult);
            }
            //test help list
            if (e.Message.Text == "#help")
            {
                e.Channel.SendMessage(e.User.Mention + " type 1d followed by a number. Example: 1d20");
            }
            if(e.Message.Text == "#cute")
            {
                e.Channel.SendFile("images/cute.png");
            }
            if (e.Message.Text == "#really?")
            {
                e.Channel.SendFile("images/annoyed_stare.png");
            }
            if (e.Message.Text == "#doyouunderstand")
            {
                e.Channel.SendMessage("https://www.youtube.com/watch?v=hWKB1Zxg84s");
            }


        }

    }
}
