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
            // Initializing hero with start hero attributes.
            LevelAttributes = new HeroAttribute(1, 1, 8);
        }

        // Override LevelUp() method by keeping the base logic which is Level++ and adding specific hero attributes to increase with each level.
        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseBy(1, 1, 5);
        }

        public override int CalculateDamage()
        {
            // Calculate damage based on attributes and equipped weapon
            int damage = 1 + LevelAttributes.Intelligence / 10;
            return damage;
        }
    }
}