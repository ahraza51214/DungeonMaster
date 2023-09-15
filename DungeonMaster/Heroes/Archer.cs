using System;

namespace DungeonMaster.Heroes
{
    // Subclass for Archer hero
    public class Archer : Hero
    {
        public Archer(string name) : base(name)
        {
            // Initializing hero with start hero attributes.
            LevelAttributes = new HeroAttribute(1, 7, 1);
        }

        // Override LevelUp() method by keeping the base logic which is Level++ and adding specific hero attributes to increase with each level.
        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseBy(1, 5, 1);
        }

        public override int CalculateDamage()
        {
            // Calculate damage based on attributes and equipped weapon
            int damage = 1 + LevelAttributes.Dexterity / 10;
            return damage;
        }
    }
}