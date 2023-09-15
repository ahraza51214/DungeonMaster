using System;
using DungeonMaster.Enums;
using DungeonMaster.Interfaces;

namespace DungeonMaster.Items
{
    // Implements Item interface
    public class Weapon : IItem
    {
        public string Name { get; set; }
        public uint RequiredLevel { get; set; }
        public Slot Slot { get; set; } = Slot.Weapon;
        public WeaponType WeaponType { get; set; }
        public int WeaponDamage { get; set; }

        // Constructor for initializing a Weapon
        public Weapon(string name, uint requiredLevel, WeaponType weaponType, int weaponDamage)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            WeaponType = weaponType;
            WeaponDamage = weaponDamage;
        }
    }
}