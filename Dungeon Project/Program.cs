using DungeonLibrary;
using System;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace DungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Introduction

            Console.WriteLine("\nWelcome Newcomer! You have entered the Dungeon of Death...\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Tons have tried, many have failed. Can you survive?\n\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\n ===== Press Any Key to Start ===== ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Player Creation
 

            Console.WriteLine("First, lets create your character");
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            bool scope = true;
            int userInput = 0;
            while (scope)
            {
                Console.WriteLine("\nPlease choose a class:\n" +
                        "1) Warrior\n" +
                        "2) Archer\n" +
                        "3) Guardian\n" +
                        "4) Assassin\n" +
                        "5) Mage\n");

                bool success = int.TryParse(Console.ReadLine(), out userInput);
                if (userInput < 6 && userInput > 0 && success)
                {
                    scope = false;
                }
                Console.Clear();
            }

            PlayerClasses playerClass = Player.GetClass(userInput);

            bool scope2 = true;
            int playerInput = 0;
            while (scope2)
            {
                Console.WriteLine("\nPlease choose a race:\n" +
                        "1) Human\n" +
                        "2) Elf\n" +
                        "3) Giant\n" +
                        "4) Dwarf\n" +
                        "5) Goblin\n");

                bool success = int.TryParse(Console.ReadLine(), out playerInput);
                if (playerInput < 6 && playerInput > 0 && success)
                {
                    scope2 = false;
                }
                Console.Clear();
            }

            Race playerRace = Player.GetRace(playerInput);

            

            Weapon equippedWeapon = Weapon.GetWeapon(0);

            Player player = new Player(name, playerRace, playerClass, equippedWeapon);
            player.GoldCoins = 0;
            player.Score = 0;

            Console.Clear();
            Console.WriteLine($"\n\n\n\nWelcome {player.Name} the {player.PlayerClass}! Best of Luck!\n" +
               $"(press any button)");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();

            #endregion

            bool quit = false;
            do
            {

                #region Monster and room generation              
                Console.WriteLine(GetRoom());
                Monster monster = Monster.GetMonster();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nIn this room is a " + monster.Name);
                Console.ResetColor();
                #endregion

                #region Encounter Loop                
                bool reload = false;
                do
                {
                    #region Menu
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "1) Attack\n" +
                        "2) Run away\n" +
                        "3) Player Info\n" +
                        "4) Monster Info\n" +
                        "5) Exit\n");

                    char action = Console.ReadKey(true).KeyChar;
                    Console.Clear();
                    switch (action)
                    {
                        case '1':
                            Console.WriteLine("Attack!");
                            reload = Combat.DoBattle(player, monster);
                            break;
                        case '2':
                            Console.WriteLine("Run Away!!");
                            Combat.DoAttack(monster, player);
                            reload = true;
                            break;
                        case '3':
                            Console.WriteLine("Player info: ");
                            Console.WriteLine(player);
                            break;

                        case '4':
                            Console.WriteLine("Monster info: ");
                            Console.WriteLine(monster);
                            break;

                        case '5':
                            Console.WriteLine("No one likes a quitter!\n");
                            quit = true;
                            break;

                        default:
                            Console.WriteLine("Do you think this is a game?? Quit playing around!\n");
                            break;
                    }
                    #endregion
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("!You died... Better luck next time!\a");
                        quit = true;
                    }

                } while (!reload && !quit);
                #endregion

            } while (!quit);

            #region Exit
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nYou defeated " + player.Score +
                " monster" + (player.Score == 1 ? "." : "s"));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nYou earned " + player.GoldCoins + " gold coin" + (player.GoldCoins == 1 ? "." : "s"));
            Console.ResetColor();

            #endregion
        }

        #region Get Room
        private static string GetRoom()
        {
            string[] rooms =
            {
                "A wide granite door in a eerie bog marks the entrance to this room. Beyond the granite door lies a massive," +
                " crumbling room. It's covered in large bones, dead insects and puddles of water.",
                "You can hear the crackling of a fire as you enter a modest square room. " +
                " The old stone walls are angled 15 degrees outward." +
                "Scattered bones line the old floor. The room is absent of light, but oil lamps line the wall.",
                "All sound seems to fade away as you enter an icy oval room, where the polished wooden walls show signs of water damage." +
                " Scattered bones line the clay floor. A single lantern is lit in the center of the room.",
                "The clinking of chains can be heard as you enter a miniscule square room." +
                " The pretty brick walls are angled 15 degrees inward. Insects surry from your sight across the timber floor." +
                " Torches in the room are already lit. A shelf can be found along the wall containing a brazier," +
                " an already burned candle and a shield.",
                "The door squeaks open as you enter a deteriorated room with battered tile walls." +
                " An elegant seal is inlayed in the stone floor. An unlit chandalier hangs overhead.",
                "A winding hallway leads you to a miniscule hexagonal room. Blood stains line the filthy tile walls." +
                " Bat droppings cover the dirt floor. A glow eminates from the opposite side of the room.",
                "This hallway leads to a dead end, causing you to turn around. When you reach the last room you left," +
                " it has changed to a foggy room; the decaying metallic walls covered in dust." +
                " Snakes slither from your sight across the dirt floor.",
                "The door squeaks open as you enter a complex septagonal room. Scattered bones line the fractured floor." +
                " Moss that lines the wall seems to be glowing, giving off a mysterious light.",
                "This hallway leads to a dead end, causing you to turn around. When you reach the last room you left," +
                " it has changed to a beautiful room, where the crumbling obsidean walls show signs of battle." +
                " Vines and plants grow from the cracks in the crumbling floor.",
                "The hair on the back of your neck stands as you enter a repulsive pentagonal room," +
                " where the filthy tile walls have missing portions that show through to the earth." +
                " Blood stains cover the stone floor. This room is completely dark, lacking torches or lamps. "
            };

            Random rand = new Random();
            int index = rand.Next(rooms.Length);
            string room = rooms[index];
            return room;
        }
        #endregion 

    }
}