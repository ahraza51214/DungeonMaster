using System;
using DungeonMaster.Enums;
using DungeonMaster.Items;

namespace DungeonMaster.Heroes
{
    // Subclass for Wizard hero
    public class Wizard : Hero
    {
        public Wizard(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(1, 1, 8);
        }

        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseBy(1, 1, 5);
        }

        public override int CalculateDamage()
        {
            // Calculate damage based on attributes and equipped weapon
            return 1 + LevelAttributes.Intelligence / 10;
        }
    }
}