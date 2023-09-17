using System;
using DungeonMaster.Enums;
using DungeonMaster.Heroes;
using DungeonMaster.Interfaces;
using DungeonMaster.Items;

namespace DungeonMasterTests.HeroesTest
{
	public class ArcherTests
    {
        [Fact]
        public void TestCalculateDamageWithNoWeapon()
        {
            // Arrange
            Hero archer = new Archer("Legolas");

            // Act & Assert
            var damage = archer.CalculateDamage();
            Assert.Equal((1 * (1 + (7 / 100))), damage); // 1 * (1 + 7 Dexterity / 100)
        }


        [Fact]
        public void TestCalculateDamageWithWeapon()
        {
            // Arrange
            Hero archer = new Archer("Legolas");
            IItem bow = new Weapon("Bow", 1, WeaponType.Bow, 10);

            // Act
            archer.Equip(bow);

            // Assert
            var damage = archer.CalculateDamage();
            Assert.Equal((10 * (1 + (7 / 100))), damage); // 10 Bow Damage * (1 + 7 Dexterity / 100)
        }


        [Fact]
        public void TestCalculateDamageWithReplacedWeapon()
        {
            // Arrange
            Hero archer = new Archer("Legolas");
            IItem bow = new Weapon("Bow", 1, WeaponType.Bow, 10);
            IItem legendaryBow = new Weapon("Legendary Bow", 1, WeaponType.Bow, 100);

            // Act
            archer.Equip(bow);
            archer.Equip(legendaryBow);

            // Assert
            var damage = archer.CalculateDamage();
            Assert.Equal((100 * (1 + (7 / 100))), damage); // 100 Legendary Bow Damage * (1 + 7 Dexterity / 100)
        }


        [Fact]
        public void TestCalculateDamageWithWeaponAndArmor()
        {
            // Arrange
            Hero archer = new Archer("Legolas");
            IItem bow = new Weapon("Bow", 1, WeaponType.Bow, 10);
            IItem leatherArmor = new Armor("Leather Armor", 1, Slot.Body, ArmorType.Leather, new HeroAttribute(0, 5, 0));

            // Act
            archer.Equip(bow);
            archer.Equip(leatherArmor);

            // Assert
            var damage = archer.CalculateDamage();
            Assert.Equal((int)(10 * (1 + (12 / 100.0))), damage); // 10 Bow Damage * (1 + ((7 Base Dexterity + 5 Armor Dexterity) / 100))
        }
    }
}