using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        private string _name;
        private int _minDamage;
        private int _maxDamage;
        private int _bonusHitChance;
        private bool _isTwoHanded;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value > 0 && value < MaxDamage ? value : 1; }
        }
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }

        public WeaponType Type { get; set; }

        public Weapon()
        {

        }

        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance,
            bool isTwoHanded, WeaponType type)
        {
            Name = name;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Name}\n" +
                   $"Damage: {MinDamage} - {MaxDamage}\n" +
                   $"Bonus Hit: {BonusHitChance}%\n" +
                   $"{(IsTwoHanded ? "Two" : "One")}-Handed {Type}";
        }

        public static Weapon GetWeapon(int index)
        {
            Weapon sword = new("Sword", 8, 12, 4, true, WeaponType.Sword);
            Weapon bow = new("Bow", 5, 8, 10, true, WeaponType.Bow);
            Weapon hammer = new("Hammer", 10, 15, 5, true, WeaponType.Hammer);
            Weapon dagger = new("Dagger", 5, 10, 8, false, WeaponType.Dagger);
            Weapon staff = new("Staff", 5, 15, 8, true, WeaponType.Staff);

            List<Weapon> weapons = new List<Weapon>()
            {
                sword,
                bow,
                hammer,
                dagger,
                staff
            };

            Weapon currentWeapon = weapons[index];
            return currentWeapon;
        }

    }
}
