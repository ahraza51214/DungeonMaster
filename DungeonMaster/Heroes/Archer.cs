﻿using System;
using DungeonMaster.Enums;
using DungeonMaster.Items;

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

        // Override CalculateDamage() method to calculate damage based on the specific attribute for hero type, with and without veileding a weapon
        public override int CalculateDamage()
        {
            // Get the equipped weapon
            if (equipmentManager.GetEquipment(Slot.Weapon) is Weapon weapon)
            {
                // Calculate the damage based on the weapon damage and dexterity
                return (int)Math.Round(weapon.WeaponDamage * (1 + LevelAttributes.Dexterity / 100.0));
            }
            // If no weapon is equipped, default WeaponDamage to 1
            return (int)Math.Round(1 * (1 + LevelAttributes.Dexterity / 100.0));
        }
    }
}