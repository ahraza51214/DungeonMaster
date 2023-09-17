using System;
using DungeonMaster.Items;
using DungeonMaster.Enums;

namespace DungeonMasterTests.ItemsTest
{
    public class WeaponTests
    {
        // Test to check the properties upon creating a new Weapon. Also to see wether a new wapon is automatically assigned the weapon Slot.
        [Fact]  
        public void WeaponConstructor_ShouldSetProperties()
        {
            // Arrange
            var weapon = new Weapon("Sword", 5, WeaponType.Sword, 20);

            // Act & Assert
            Assert.Equal("Sword", weapon.Name);
            Assert.Equal(5, (int)weapon.RequiredLevel);
            Assert.Equal(Slot.Weapon, weapon.Slot);
            Assert.Equal(WeaponType.Sword, weapon.WeaponType);
            Assert.Equal(20, weapon.WeaponDamage);
        }
    }
}