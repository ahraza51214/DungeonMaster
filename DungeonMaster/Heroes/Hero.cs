using System;
using DungeonMaster.Enums;
using DungeonMaster.Interfaces;
using DungeonMaster.Items;
using System.Text;
using DungeonMaster.Equipment;

namespace DungeonMaster.Heroes
{
    // Abstract class for heroes
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; protected set; }
        public HeroAttribute LevelAttributes { get; protected set; }
        public readonly EquipmentManager equipmentManager;

        public Hero(string name)
        {
            Name = name;
            Level = 1;
            LevelAttributes = new HeroAttribute(0, 0, 0);
            equipmentManager = new EquipmentManager();
        }

        // Abstract method to level up a hero (implemented in subclasses)
        public virtual void LevelUp()
        {
            Level++;
        }

        // Method to equip an item to the hero
        public void Equip(IItem item)
        {
            equipmentManager.Equip(item, this);
        }

        // Abstract method to calculate hero damage (implemented in subclasses)
        public abstract int CalculateDamage();

        // Method to calculate the total attributes of the hero
        public HeroAttribute CalculateTotalAttributes()
        {
            int totalStrength = LevelAttributes.Strength;
            int totalDexterity = LevelAttributes.Dexterity;
            int totalIntelligence = LevelAttributes.Intelligence;

            foreach (Slot slot in Enum.GetValues(typeof(Slot)))
            {
                IItem equippedItem = equipmentManager.GetEquipment(slot);

                if (equippedItem is Armor armor)
                {
                    totalStrength += armor.ArmorAttribute.Strength;
                    totalDexterity += armor.ArmorAttribute.Dexterity;
                    totalIntelligence += armor.ArmorAttribute.Intelligence;
                }
            }
            return new HeroAttribute(totalStrength, totalDexterity, totalIntelligence);
        }

        // Method to display hero information using string builder
        public string Display()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Name: {Name}");
            builder.AppendLine($"Class: {GetType().Name}");
            builder.AppendLine($"Level: {Level}");

            HeroAttribute totalAttributes = CalculateTotalAttributes();
            builder.AppendLine($"Total Strength: {totalAttributes.Strength}");
            builder.AppendLine($"Total Dexterity: {totalAttributes.Dexterity}");
            builder.AppendLine($"Total Intelligence: {totalAttributes.Intelligence}");
            builder.AppendLine($"Damage: {CalculateDamage()}");

            return builder.ToString();
        }
    }
}