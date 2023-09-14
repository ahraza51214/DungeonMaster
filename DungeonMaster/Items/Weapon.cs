using System;
using DungeonMaster.Enums;
using DungeonMaster.Interfaces;

namespace DungeonMaster.Items
{
    public class Weapon : IItem
    {
        public string? Name { get; set; } // Add the public setter
        public int RequiredLevel { get; set; }
        public Slot Slot { get; set; }
        public WeaponType WeaponType { get; set; }
        public int WeaponDamage { get; set; }
    }
}