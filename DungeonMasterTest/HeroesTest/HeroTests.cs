using System;
using DungeonMaster.Enums;
using DungeonMaster.Heroes;
using DungeonMaster.Interfaces;
using DungeonMaster.Items;

namespace DungeonMasterTests.HeroesTest
{
	public class HeroTests
	{
        [Fact]
        public void TestHeroCreation()
        {
            // Arrange
            Hero barbarian = new Barbarian("Aragorn");

            // Assert
            Assert.Equal("Aragorn", barbarian.Name);
            Assert.Equal(1, barbarian.Level);
            Assert.Equal(5, barbarian.LevelAttributes.Strength);
            Assert.Equal(2, barbarian.LevelAttributes.Dexterity);
            Assert.Equal(1, barbarian.LevelAttributes.Intelligence);
        }


        [Fact]
        public void TestHeroLevelUp()
        {
            // Arrange
            Hero barbarian = new Barbarian("Aragorn");

            // Act
            barbarian.LevelUp();

            // Assert
            Assert.Equal(2, barbarian.Level);
            Assert.Equal(8, barbarian.LevelAttributes.Strength);
            Assert.Equal(4, barbarian.LevelAttributes.Dexterity);
            Assert.Equal(2, barbarian.LevelAttributes.Intelligence);
        }


        [Fact]
        public void TestCalculateTotalAttributesWithOnePieceOfArmor()
        {
            // Arrange
            Hero barbarian = new Barbarian("Aragorn");
            IItem plateArmor = new Armor("Steel Plate Mail", 1, Slot.Body, ArmorType.Plate, new HeroAttribute(20, 0, 0));

            // Act
            barbarian.Equip(plateArmor);

            // Assert
            var totalAttributes = barbarian.CalculateTotalAttributes();
            Assert.Equal(25, totalAttributes.Strength); // 5 (Base) + 20 (Plate Armor)
            Assert.Equal(2, totalAttributes.Dexterity); // Base Dexterity 2
            Assert.Equal(1, totalAttributes.Intelligence); // Base Intelligence 1
        }


        [Fact]
        public void TestCalculateTotalAttributesWithTwoPieceOfArmor()
        {
            // Arrange
            Hero barbarian = new Barbarian("Aragorn");
            IItem plateArmor = new Armor("Steel Plate Mail", 1, Slot.Body, ArmorType.Plate, new HeroAttribute(20, 0, 0));
            IItem legArmor = new Armor("Steel Leg Mail", 1, Slot.Legs, ArmorType.Plate, new HeroAttribute(10, 0, 0));

            // Act
            barbarian.Equip(plateArmor);
            barbarian.Equip(legArmor);

            // Assert
            var totalAttributes = barbarian.CalculateTotalAttributes();
            Assert.Equal(35, totalAttributes.Strength); // 5 (Base) + 20 (Plate Armor) + 10 (Leg Armor)
            Assert.Equal(2, totalAttributes.Dexterity); // Base Dexterity 2
            Assert.Equal(1, totalAttributes.Intelligence); // Base Intelligence 1
        }


        [Fact]
        public void TestCalculateTotalAttributesWithReplacedArmor()
        {
            // Arrange
            Hero barbarian = new Barbarian("Aragorn");
            IItem simpleArmor = new Armor("Simple Armor", 1, Slot.Body, ArmorType.Plate, new HeroAttribute(10, 0, 0));
            IItem plateArmor = new Armor("Steel Plate Mail", 1, Slot.Body, ArmorType.Plate, new HeroAttribute(30, 0, 0));


            // Act
            barbarian.Equip(simpleArmor);
            barbarian.Equip(plateArmor);

            // Assert
            var totalAttributes = barbarian.CalculateTotalAttributes();
            Assert.Equal(30, totalAttributes.Strength); // 5 (Base) + 20 (Plate Armor) + 10 (Leg Armor)
            Assert.Equal(2, totalAttributes.Dexterity); // Base Dexterity 2
            Assert.Equal(1, totalAttributes.Intelligence); // Base Intelligence 1
        }


        [Fact]
        public void TestHeroDisplay()
        {
            // Arrange
            Hero barbarian = new Barbarian("Aragorn");

            // Act
            string display = barbarian.Display();

            // Assert
            Assert.Contains("Name: Aragorn", display);
            Assert.Contains("Class: Barbarian", display);
            Assert.Contains("Level: 1", display);
            Assert.Contains("Total Strength: 5", display);
            Assert.Contains("Total Dexterity: 2", display);
            Assert.Contains("Total Intelligence: 1", display);
        }
    }
}