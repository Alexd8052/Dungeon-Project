using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        public Race PlayerRace { get; set; }
        public PlayerClasses PlayerClass { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public int Score { get; set; }
        public int GoldCoins { get; set; }


        public Player(string name, Race playerRace, PlayerClasses playerClass, Weapon equippedWeapon) :
            base(name, 75, 5, 50)
        {
            PlayerRace = playerRace;
            PlayerClass = playerClass;
            EquippedWeapon = equippedWeapon;

            #region Racial Bonuses
            switch (PlayerRace)
            {
                case Race.Human:
                    HitChance += 2;
                    Life -= 8;
                    MaxLife -= 8;
                    break;
                case Race.Elf:
                    HitChance += 5;
                    Life -= 5;
                    MaxLife -= 5;
                    break;
                case Race.Giant:
                    HitChance += 3;
                    Life -= 0;
                    MaxLife -= 0;
                    break;
                case Race.Dwarf:
                    HitChance += 0;
                    Life -= 10;
                    MaxLife -= 10;
                    break;
                case Race.Goblin:
                    HitChance += 1;
                    Life -= 5;
                    MaxLife -= 5;
                    break;
                default:
                    break;
            }
            #endregion

            #region Class Bonuses
            switch (PlayerClass)
            {
                case PlayerClasses.Warrior:
                    HitChance += 2;
                    Life -= 8;
                    MaxLife -= 8;
                    EquippedWeapon = Weapon.GetWeapon(0);
                    break;
                case PlayerClasses.Archer:
                    HitChance += 5;
                    Life -= 5;
                    MaxLife -= 5;
                    EquippedWeapon = Weapon.GetWeapon(1);
                    break;
                case PlayerClasses.Guardian:
                    HitChance += 3;
                    Life -= 0;
                    MaxLife -= 0;
                    EquippedWeapon = Weapon.GetWeapon(2);
                    break;
                case PlayerClasses.Assassin:
                    HitChance += 0;
                    Life -= 10;
                    MaxLife -= 10;
                    EquippedWeapon = Weapon.GetWeapon(3);
                    break;
                case PlayerClasses.Mage:
                    HitChance += 1;
                    Life -= 5;
                    MaxLife -= 5;
                    EquippedWeapon = Weapon.GetWeapon(4);
                    break;
                default:
                    break;
            }
            #endregion
        }

        public Player()
        {

        }

        public static string GetRaceDesc(Race race)
        {
            switch (race)
            {
                case Race.Human:
                    return "A worthy fighter!";
                case Race.Elf:
                    return "An elusive being with pointed ears";
                case Race.Giant:
                    return "Looks like a human but is much larger and stronger";
                case Race.Dwarf:
                    return "Short, stout, bearded and fond of singing, drinking, mining and fighting.";
                case Race.Goblin:
                    return "A sneaky mischievous creature";
                default:
                    return "";
            }
        }

        private static void ChooseClass(ref bool scope, ref int userInput)
        {
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
        }

        public static PlayerClasses GetClass(int userClassChoice)
        {
            PlayerClasses playerClass = new PlayerClasses();

            switch (userClassChoice)
            {
                case 1:
                    playerClass = PlayerClasses.Warrior; 
                    break;
                case 2:
                    playerClass = PlayerClasses.Archer;
                    break;
                case 3:
                    playerClass = PlayerClasses.Guardian;
                    break;
                case 4:
                    playerClass = PlayerClasses.Assassin;
                    break;
                case 5:
                    playerClass = PlayerClasses.Mage;
                    break;
            }
            return playerClass;
        }

        private static void ChooseRace(ref bool scope, ref int userInput)
        {
            while (scope)
            {
                Console.WriteLine("\nPlease choose a race:\n" +
                        "1) Human\n" +
                        "2) Elf\n" +
                        "3) Giant\n" +
                        "4) Dwarf\n" +
                        "5) Goblin\n");

                bool success = int.TryParse(Console.ReadLine(), out userInput);
                if (userInput < 6 && userInput > 0 && success)
                {
                    scope = false;
                }
                Console.Clear();
            }
        }

        public static Race GetRace(int userRaceChoice)
        {
            Race playerRace = new Race();

            switch (userRaceChoice)
            {
                case 1:
                    playerRace = Race.Human;
                    break;
                case 2:
                    playerRace = Race.Elf;
                    break;
                case 3:
                    playerRace = Race.Giant;
                    break;
                case 4:
                    playerRace = Race.Dwarf;
                    break;
                case 5:
                    playerRace = Race.Goblin;
                    break;
            }
            return playerRace;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nWeapon: \n{EquippedWeapon}\n" +
                $"Description: \n{GetRaceDesc(PlayerRace)}";
        }

        public override int CalcDamage()
        {
            ;
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }
        public override int CalcHitChance()
        {
            int chance = HitChance + EquippedWeapon.BonusHitChance;
            return chance;
        }


    }

}

