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
            LevelAttributes = new HeroAttribute(2, 6, 1);
        }

        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseBy(1, 4, 1);
        }

        public override int CalculateDamage()
        {
            // Calculate damage based on attributes and equipped weapon
            return 1 + LevelAttributes.Dexterity / 10;
        }
    }

}