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


        public Player(string name, Race playerRace, PlayerClasses playerClass, Weapon equippedWeapon)
            : base(name, 75, 5, 50)//hitchance, block, maxlife/life
        {
            Name = name;
            PlayerClass = playerClass;
            PlayerRace = playerRace;
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
        }

        public Player(string name, int hitChance, int block, int maxLife) : base(name, hitChance, block, maxLife)
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

