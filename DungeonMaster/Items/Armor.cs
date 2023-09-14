using System;
using DungeonMaster.Enums;
using DungeonMaster.Interfaces;
using DungeonMaster.Heroes;

namespace DungeonMaster.Items
{
    public class Armor : IItem
    {
        public string? Name { get; set; } // Add the public setter
        public int RequiredLevel { get; set; }
        public Slot Slot { get; set; }
        public ArmorType ArmorType { get; set; }
        public HeroAttribute? ArmorAttribute { get; set; }

    }
}