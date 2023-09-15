using System;
using DungeonMaster.Enums;
using DungeonMaster.Heroes;
using DungeonMaster.Items;

namespace DungeonMasterTests.ItemsTest
{
	public class ArmorTests
	{
        [Fact]
        public void ArmorConstructor_ShouldSetProperties()
        {
            // Arrange & Act
            var armor = new Armor("Plate Mail", 10, Slot.Body, ArmorType.Plate, new HeroAttribute(10, 5, 0));

            // Assert
            Assert.Equal("Plate Mail", armor.Name);
            Assert.Equal(10, (int)armor.RequiredLevel);
            Assert.Equal(Slot.Body, armor.Slot);
            Assert.Equal(ArmorType.Plate, armor.ArmorType);
            Assert.Equal(10, armor.ArmorAttribute.Strength);
            Assert.Equal(5, armor.ArmorAttribute.Dexterity);
            Assert.Equal(0, armor.ArmorAttribute.Intelligence);
        }
    }
}