using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            int chance = attacker.CalcHitChance() - defender.CalcBlock();
            int roll = new Random().Next(1, 101);
            bool hit = roll <= chance;

            Thread.Sleep(300);

            if (hit)
            {
                int damage = attacker.CalcDamage();

                defender.Life -= damage;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} damage!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{attacker.Name} ");
                Console.ResetColor();
                Console.WriteLine("missed!");
            }
        }

        public static bool DoBattle(Player player, Monster monster)
        {

            DoAttack(player, monster);
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
                return false;
            }
            else
            {
                player.GoldCoins++;
                player.Score++;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nYou killed {monster.Name}!\n");
                Console.ResetColor();
                Console.ForegroundColor= ConsoleColor.DarkYellow;
                Console.WriteLine("You earned 1 gold coin\n");
                Console.WriteLine("Gold Coins: " + player.GoldCoins + "\n\n");
                Console.ResetColor();

                return true;
            }
        }
    }
}
