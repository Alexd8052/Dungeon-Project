using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player
    {
        //FIELDS


        //PROPS
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public int Score { get; set; }

        //CTORs
        public Player (Race playerRace, Weapon equippedWeapon)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;
        }

        //METHODS

    }
}
