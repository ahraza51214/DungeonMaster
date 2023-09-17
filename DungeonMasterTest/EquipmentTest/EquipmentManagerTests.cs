namespace DungeonMasterTests.EquipmentTest
{
    public class EquipmentManagerTests
    {
        [Fact]
        public void Equip_ShouldEquipWeaponToHero()
        {
            // Arrange
            var equipmentManager = new EquipmentManager();
            var hero = new Barbarian("Aragorn");
            var weapon = new Weapon("Sword", 1, WeaponType.Sword, 20);

            // Act
            var result = equipmentManager.Equip(weapon, hero);

            // Assert
            Assert.True(result);
            Assert.Equal(weapon, equipmentManager.GetEquipment(Slot.Weapon));
        }

        [Fact]
        public void Equip_ShouldThrowExceptionIfHeroLevelIsTooLow()
        {
            // Arrange
            var equipmentManager = new EquipmentManager();
            var hero = new Barbarian("Aragorn");
            var weapon = new Weapon("Sword", 10, WeaponType.Sword, 20);

            // Act and Assert
            Assert.Throws<InvalidEquipmentException>(() => equipmentManager.Equip(weapon, hero));
        }

        [Fact]
        public void Equip_ShouldThrowExceptionIfInvalidWeaponTypeForHero()
        {
            // Arrange
            var equipmentManager = new EquipmentManager();
            var hero = new Wizard("Gandalf");
            var weapon = new Weapon("Bow", 1, WeaponType.Bow, 20);

            // Act and Assert
            Assert.Throws<InvalidEquipmentException>(() => equipmentManager.Equip(weapon, hero));
        }

        [Fact]
        public void Equip_ShouldEquipArmorToHero()
        {
            // Arrange
            var equipmentManager = new EquipmentManager();
            Hero swashbuckler = new Swashbuckler("Boromir");
            IItem leatherArmor = new Armor("Leather Armor", 1, Slot.Body, ArmorType.Leather, new HeroAttribute(5, 5, 0));

            // Act
            var result = equipmentManager.Equip(leatherArmor, swashbuckler);

            // Assert
            Assert.True(result);
            Assert.Equal(leatherArmor, equipmentManager.GetEquipment(Slot.Body));
        }

        [Fact]
        public void Equip_ShouldThrowExceptionIfInvalidArmorTypeForHero()
        {
            // Arrange
            Hero wizard = new Wizard("Gandalf");
            IItem plateArmor = new Armor("Plate Armor", 1, Slot.Body, ArmorType.Plate, new HeroAttribute(10, 0, 0));

            // Act & Assert
            Assert.Throws<InvalidEquipmentException>(() => wizard.Equip(plateArmor));
        }
    }
}