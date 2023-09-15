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

        // Override CalculateDamage() method to add specific logic for hero
        public override int CalculateDamage()
        {
            // Get the equipped weapon
            if (equipmentManager.GetEquipment(Slot.Weapon) is Weapon weapon)
            {
                // Calculate the damage based on the weapon damage and intelligence
                return (int)(weapon.WeaponDamage * (1 + LevelAttributes.Intelligence / 100.0));
            }
            // If no weapon is equipped, default WeaponDamage to 1
            return (int)(1 * (1 + LevelAttributes.Intelligence / 100.0));
        }
    }
}