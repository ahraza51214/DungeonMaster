using System;
using DungeonMaster.Enums;
using DungeonMaster.Heroes;
using DungeonMaster.Interfaces;
using DungeonMaster.Items;
using DungeonMaster.ExceptionHandling;

namespace DungeonMaster.Equipment
{
    // Class to manage hero equipment
    public class EquipmentManager
    {
        private readonly Dictionary<Slot, IItem?> equipment;

        public EquipmentManager()
        {
            // Initialize equipment slots with null values
            equipment = new Dictionary<Slot, IItem?>
            {
                { Slot.Weapon, null },
                { Slot.Head, null },
                { Slot.Body, null },
                { Slot.Legs, null }
            };
        }

        // Method to equip an item to a hero
        public bool Equip(IItem item, Hero hero)
        {
            // Check if the hero's level is sufficient to equip the item
            if (item.RequiredLevel > hero.Level)
            {
                throw new InvalidOperationException("Hero's level is too low to equip this item.");
            }

            // Check if the item is a weapon
            if (item is Weapon weapon)
            {
                // Check if the hero can equip this weapon type, if not use the created InvalidEquipmentException method 
                if (!CanEquipWeapon(hero, weapon.WeaponType))
                {
                    throw new InvalidEquipmentException($"Hero {hero.Name} cannot equip {weapon.WeaponType}.");
                }

                // Equip the weapon
                equipment[Slot.Weapon] = weapon;
            }
            // Check if the item is armor
            else if (item is Armor armor)
            {
                // Check if the hero can equip this armor type
                if (!CanEquipArmor(hero, armor.ArmorType))
                {
                    throw new InvalidEquipmentException($"Hero {hero.Name} cannot equip {armor.ArmorType}.");
                }
                // Equip the armor
                equipment[armor.Slot] = armor;
            }

            return true;
        }

        // Method to retrieve the item in a specific equipment slot
        public IItem? GetEquipment(Slot slot)
        {
            if (equipment.ContainsKey(slot))
            {
                return equipment[slot];
            }
            return null;
        }

        // Method to determine if a hero can equip a weapon type
        private static bool CanEquipWeapon(Hero hero, WeaponType weaponType)
        {
            switch (hero)
            {
                case Wizard:
                    return weaponType == WeaponType.Staff || weaponType == WeaponType.Wand;
                case Archer:
                    return weaponType == WeaponType.Bow;
                case Swashbuckler:
                    return weaponType == WeaponType.Dagger || weaponType == WeaponType.Sword;
                case Barbarian:
                    return weaponType == WeaponType.Hatchet || weaponType == WeaponType.Mace || weaponType == WeaponType.Sword;
                default:
                    return false;
            }
        }

        // Method to determine if a hero can equip an armor type
        private static bool CanEquipArmor(Hero hero, ArmorType armorType)
        {
            switch (hero)
            {
                case Wizard:
                    return armorType == ArmorType.Cloth;
                case Archer:
                    return armorType == ArmorType.Leather || armorType == ArmorType.Mail;
                case Swashbuckler:
                    return armorType == ArmorType.Leather || armorType == ArmorType.Mail;
                case Barbarian:
                    return armorType == ArmorType.Mail || armorType == ArmorType.Plate;
                default:
                    return false;
            }
        }
    }
}