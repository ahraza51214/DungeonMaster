using System;

namespace DungeonMaster.Heroes
{
    // Subclass for Barbarian hero
    public class Barbarian : Hero
    {
        public Barbarian(string name) : base(name)
        {
            // Initializing hero with start hero attributes.
            LevelAttributes = new HeroAttribute(5, 2, 1);
        }

        // Override LevelUp() method by keeping the base logic which is Level++ and adding specific hero attributes to increase with each level.
        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseBy(3, 2, 1);
        }

        public override int CalculateDamage()
        {
            // Calculate damage based on attributes and equipped weapon
            int damage = 1 + LevelAttributes.Strength / 10;
            return damage;
        }
    }
}