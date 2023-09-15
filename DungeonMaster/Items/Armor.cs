using System;
using DungeonMaster.Enums;
using DungeonMaster.Interfaces;
using DungeonMaster.Heroes;

namespace DungeonMaster.Items
{
    // Implements Item interface
    public class Armor : IItem
    {
        public string Name { get; set; }
        public uint RequiredLevel { get; set; }
        public Slot Slot { get; set; }
        public ArmorType ArmorType { get; set; }
        public HeroAttribute ArmorAttribute { get; set; }

        // Constructor for initializing an Armor
        public Armor(string name, uint requiredLevel, Slot slot, ArmorType armorType, HeroAttribute armorAttribute)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;
            ArmorType = armorType;
            ArmorAttribute = armorAttribute;
        }
    }
}