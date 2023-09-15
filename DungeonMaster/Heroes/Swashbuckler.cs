using System;
using DungeonMaster.Enums;
using DungeonMaster.Items;

namespace DungeonMaster.Heroes
{
    // Subclass for Swashbuckler hero
    public class Swashbuckler : Hero
    {
        public Swashbuckler(string name) : base(name)
        {
            // Initializing hero with start hero attributes.
            LevelAttributes = new HeroAttribute(2, 6, 1);
        }

        // Override LevelUp() method by keeping the base logic which is Level++ and adding specific hero attributes to increase with each level.
        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseBy(1, 4, 1);
        }

        public override int CalculateDamage()
        {
            // Calculate damage based on attributes and equipped weapon
            int damage = 1 + LevelAttributes.Dexterity / 10;
            return damage;
        }
    }
}