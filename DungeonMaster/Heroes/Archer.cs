using System;

namespace DungeonMaster.Heroes
{
    // Subclass for Archer hero
    public class Archer : Hero
    {
        public Archer(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(1, 7, 1);
        }

        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseBy(1, 5, 1);
        }

        public override int CalculateDamage()
        {
            // Calculate damage based on attributes and equipped weapon
            return 1 + LevelAttributes.Dexterity / 10;
        }
    }
}

