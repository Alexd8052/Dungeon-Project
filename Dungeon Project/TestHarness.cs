using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonApp
{
    internal class TestHarness
    {
        static void Main(string[] args)
        {
            //test your Character and your Weapon creation

            #region Weapon Testing
            Console.Write("Equipped Weapon: ");
            Weapon w1 = new Weapon("Wooden Stick", 1, 5, 5, false, WeaponType.Sword);
            Console.WriteLine(w1.ToString());
            #endregion

            #region Player Testing
            Console.WriteLine("Player: ");
            Console.Write("What is your name? ");
            string name = "The Big One";

            Race race = (Race)2;

            
            #endregion

            #region Monster testing
            Monster m1 = Monster.GetMonster();
            Console.WriteLine(m1);

            m1.Life += 10;
            Console.WriteLine(m1);
            #endregion
        }
    }
}
