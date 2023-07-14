using DungeonLibrary;
using System.Numerics;
using System.Threading;

namespace DungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Intro
            //TODO Intro
            Console.WriteLine("TITLE");
            Console.WriteLine("Description Text");
            Console.WriteLine("Press Enter to Start");
            Console.ReadKey();
            #endregion

            #region Player Creation

            //TODO Create player
            //Potential expansion - Let the user choose from a list of pre-made weapons.
            //Potential Expansion - Let the user choose their name and Race

            #endregion

            //Outer Loop
            bool quit = false;
            do
            {
                #region Monster and Room Generation

                //TODO Generate a room - random string description
                //TODO Generate monster

                #endregion

                #region Encounter Loop

                bool reload = false;
                do
                {
                    #region MENU

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
                            //TODO Attack
                            break;
                        case '2':
                            Console.WriteLine("Run Away!!");
                            //TODO Run away
                            break;
                        case '3':
                            Console.WriteLine("Player info: ");
                            //TODO Player info
                            break;

                        case '4':
                            Console.WriteLine("Monster info: ");
                            //TODO Monster info
                            break;

                        case '5':
                            //quit the whole game. "reload = true;" gives us a new room and monster, "quit = true" quits the game, leaving both the inner AND outer loops.
                            Console.WriteLine("No one likes a quitter!");
                            quit = true;
                            break;

                        default:
                            Console.WriteLine("Do you think this is a game?? Quit playing around!");
                            break;
                    }//end switch

                    #endregion
                } while (!reload && !quit);//While reload and quit are both FALSE (!true), keep looping. If either becomes true, leave the inner loop.

                #endregion

            } while (!quit);//While quit is NOT true, keep looping.

            #region Exit
            //TODO Update/Customize Exit (give player their score or how many monsters they killed)
            Console.WriteLine("You defeated the monster!");
            #endregion
        }//end Main()
    }//End class
}//end namespace