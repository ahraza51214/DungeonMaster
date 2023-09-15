using System;
using DungeonMaster.Items;
using DungeonMaster.Enums;

namespace DungeonMasterTests.ItemsTest
{
    public class WeaponTests
    {
        public class ItemTests
        {
            [Fact]  
            public void WeaponConstructor_ShouldSetProperties()
            {
                // Arrange & Act
                var weapon = new Weapon("Sword", 5, WeaponType.Sword, 20);

                // Assert
                Assert.Equal("Sword", weapon.Name);
                Assert.Equal(5, (int)weapon.RequiredLevel);
                Assert.Equal(Slot.Weapon, weapon.Slot);
                Assert.Equal(WeaponType.Sword, weapon.WeaponType);
                Assert.Equal(20, weapon.WeaponDamage);
            }
        }
    }
}