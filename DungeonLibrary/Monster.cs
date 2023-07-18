using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;

        public int MaxDamage { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = (value > 0 && value < MaxDamage) ? value : 1;
            }
        }

        public string Description { get; set; }

        public Monster(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description)
            : base(name, hitChance, block, maxLife)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }
        public Monster()
        {

        }

        public override string ToString()
        {
            return $"*********** MONSTER ***********\n" +
                $"{base.ToString()}\n" +
                $"Damage: {MinDamage} - {MaxDamage}\n" +
                $"Description: {Description}";
        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }

        public static Monster GetMonster()
        {
            Monster m1 = new("Zombie", 50, 20, 25, 8, 2, "Undead being covered in rotting flesh");
            Monster m2 = new("Skeleton", 70, 20, 25, 8, 2, "Stack of bones with a mind of its own");
            Monster m3 = new("Rat", 50, 20, 25, 8, 2, "A large disgusting rodent");
            Monster m4 = new("Hellhound", 45, 25, 40, 12, 5, "A demon hound from the underworld");

            List<Monster> monsters = new()
            {
                m1, m1,
                m2, m2, m2, m2,
                m3, m3, m3,
                m4
            };

            Random rand = new Random();
            int index = rand.Next(monsters.Count);
            Monster monster = monsters[index];
            return monster;

        }
    }
}
