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
            var expectedDamage = Math.Round(1 * 1.07); // 1 No Weapon * (1 + 7 Dexterity / 100)
            Assert.Equal(expectedDamage, damage);
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
            var expectedDamage = Math.Round(10 * 1.07); // 10 Bow Damage * (1 + 7 Dexterity / 100)
            Assert.Equal(expectedDamage, damage); 
        }


        [Fact]
        public void TestCalculateDamageWithReplacedWeapon()
        {
            // Arrange
            Hero archer = new Archer("Legolas");
            IItem bow = new Weapon("Bow", 1, WeaponType.Bow, 10);
            IItem legendaryBow = new Weapon("Legendary Bow", 1, WeaponType.Bow, 50);

            // Act
            archer.Equip(bow);
            archer.Equip(legendaryBow);

            // Assert
            var damage = archer.CalculateDamage();
            double expectedDamage = Math.Round(50 * 1.07);  // 50 Legendary Bow Damage * (1 + 7 Dexterity / 100)
            Assert.Equal(expectedDamage, damage);
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
            var expectedDamage = Math.Round(10 * 1.12); // 10 Bow Damage * (1 + ((7 Base Dexterity + 5 Armor Dexterity) / 100))
            Assert.Equal(expectedDamage, damage);
        }
    }
}