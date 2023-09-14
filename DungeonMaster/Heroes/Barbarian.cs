using System;
using DungeonMaster.Enums;
using DungeonMaster.Items;

namespace DungeonMaster.Heroes
{
    // Subclass for Barbarian hero
    public class Barbarian : Hero
    {
        public Barbarian(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(5, 2, 1);
        }

        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseBy(3, 2, 1);
        }

        public override int CalculateDamage()
        {
            // Calculate damage based on attributes and equipped weapon
            return 1 + LevelAttributes.Strength / 10;
        }
    }
}