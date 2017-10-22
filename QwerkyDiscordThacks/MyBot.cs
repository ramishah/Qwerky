/* Welcome to the code for the Qwerty Bot - C#
 * Made for THacks 2 2017
 * By: Tarannum Tasnuva, Oishee Syed, Alexandra Vidal, Arafat Syed Shah and Rami Shah
 */

using Discord;                  //We're using the Discord.NET libraries and command lines 
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QwerkyDiscordThacks
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        Random rand;

        string[] pics;
        string[] eightball;
        string[] mathquestions;
        string[] fact;
        string[] animal;



        public MyBot()

        {
            rand = new Random();
            pics = new string[]
                {

                    "Pics/apple.jpg",
                    "Pics/banana.jpg",
                    "Pics/car.jpeg"
                };

            eightball = new string[]
            {
                "yes Definetly",
                "is no",
                "out look good",
                "hmmmm No",
                "try again later",
                "minimal chance",
                "not very likely",
                "probably",
                "very likey",
                "certain of it",
                "is oof"

            };

           mathquestions = new string[]
            {
                "4+5=?" ,
                "20-9=?" ,
                "10+13=?" ,
                "5x2=?" ,
                "18-3=?" ,
                "90-65+2=?" ,
                "2x7x4=?" ,
                "90-43+12=?" ,
                "10-10-10=?" ,
                "78-23+25=?" ,
                "1+?=7" ,
                "89-23=?"

              };

            fact = new string[]
            {
                "It is impossible for most people to lick their own elbow. (try it!)",
                "A crocodile cannot stick its tongue out.",
                "A shrimp's heart is in its head.",
                "It is physically impossible for pigs to look up into the sky",
                "The \"sixth sick sheik's sixth sheep's sick\" is believed to be the toughest tongue twister in the English language.",
                "If you sneeze too hard, you could fracture a rib.",
                "Wearing headphones for just an hour could increase the bacteria in your ear by 700 times.",
                "In the course of an average lifetime, while sleeping you might eat around 70 assorted insects and 10 spiders, or more.",
                "Some lipsticks contain fish scales.",
                "There are 293 ways to make change for a dollar.",
                "A shark is the only known fish that can blink with both eyes.",
                "\"Dreamt\" is the only English word that ends in the letters \"mt\".",
                "A cat has 32 muscles in each ear.",
                "An ostrich's eye is bigger than its brain.",
                "Arafat is plat in league"
                            };

            animal = new string[]
            {
                "Elephant",
                "Snake",
                "Ostrich",
                "Chicken",
                "Leopard",
                "Monkey",
                "Lion",
                "Bat",
                "Catfish",
                "Dog",
                "Alligator",
                "Crow",
                "Blue Whale",
                "Arctic Wolf",
                "Cow",
                "Cougar",
                "Brown Bear",
                "Panther",
                "Rattlesnake",
                "Zebra",
                "Caterpillar"
            };
              

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();
            
            RegisterPicCommand();

            EightBall();

            MathQuestion();

            Fact();

            Animal();
           
                     
            {
                commands.CreateCommand("hello")
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("Hey there! Welcome to QWERkY. The smart bot! \n\n What would you like to do? For command help, type \"!help\"");
                    });

                commands.CreateCommand("help")
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("Heard you needed help! Here's some commands...\n\n\"!fact\" - tells you a random fact, that you probably didn't know!\n\"!math\" - gives you a math problem, better solve quick!\n\"!8ball <question>\" - wanna ask the mysterious 8 ball a question? put in the command and put in a question!");
                    });

                commands.CreateCommand("compliment")
                        .Do(async (e) =>
                        {
                            await e.Channel.SendMessage("Your amazing!");
                        });

            }
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzcxNDQ1ODEyMzY0MDUwNDM0.DM17vA.cnu2AC8rkxke7m-n7Ys9iJvT7W0", TokenType.Bot);
            });
        }

        private void RegisterPicCommand()
        {
            commands.CreateCommand("pic")
                .Do(async (e) =>
               {
                   int randomPic = rand.Next(pics.Length);
                   string PicToPost = pics[randomPic];
                   await e.Channel.SendFile(PicToPost);
               });
        }

        private void EightBall()
        {
            commands.CreateCommand("8ball").Parameter("",ParameterType.Multiple)
                .Do(async (e) =>
                {
                    
                    int randomeightball = rand.Next(0,11);
                    await e.Channel.SendMessage((e.User.Name) + ", my answer is " + eightball[randomeightball]);
                });
        }


        private void Fact()
        {
            commands.CreateCommand("fact")
                .Do(async (e) =>
                {
                    int newfact = rand.Next(0, 15);
                    await e.Channel.SendMessage("" + fact[newfact]);


                });
        }

        private void Animal()
        {
            commands.CreateCommand("animal")
                .Do(async (e) =>
              {
                  int newanimal = rand.Next(0, 21);
                  await e.Channel.SendMessage("" + animal[newanimal]);
              });
        }
        
        private void MathQuestion()
        {
            commands.CreateCommand("math")
                .Do(async (e) =>
            {
                int newmath = rand.Next(0, 12);
                await e.Channel.SendMessage("What is the answer of " + mathquestions[newmath]);

            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
