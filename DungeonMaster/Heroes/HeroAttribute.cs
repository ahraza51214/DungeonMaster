using System;
namespace DungeonMaster.Heroes
{
    // Class to represent hero attributes
    public class HeroAttribute
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public void IncreaseBy(int strength, int dexterity, int intelligence)
        {
            // Increase the attributes by the corresponding values from each hero
            Strength += strength;
            Dexterity += dexterity;
            Intelligence += intelligence;
        }
    }
}

