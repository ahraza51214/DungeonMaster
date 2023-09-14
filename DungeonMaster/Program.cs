using DungeonMaster.Enums;
using DungeonMaster.Heroes;
using DungeonMaster.Interfaces;
using DungeonMaster.Items;
using DungeonMaster.ExceptionHandling;

class Program
{
    static void Main(string[] args)
    {
        // Create heroes
        Hero wizard = new Wizard("Gandalf");
        Hero archer = new Archer("Legolas");
        Hero swashbuckler = new Swashbuckler("Jack");
        Hero barbarian = new Barbarian("Ejaz");

        // Level up heroes
        wizard.LevelUp();
        archer.LevelUp();
        swashbuckler.LevelUp();
        barbarian.LevelUp();
        wizard.LevelUp();

        // Equip weapons
        IItem staff = new Weapon { Name = "Magic Staff", RequiredLevel = 1, Slot = Slot.Weapon, WeaponType = WeaponType.Staff, WeaponDamage = 10 };
        IItem bow = new Weapon { Name = "Longbow", RequiredLevel = 1, Slot = Slot.Weapon, WeaponType = WeaponType.Bow, WeaponDamage = 15 };
        IItem sword = new Weapon { Name = "Sword", RequiredLevel = 1, Slot = Slot.Weapon, WeaponType = WeaponType.Sword, WeaponDamage = 20 };
        IItem dagger = new Weapon { Name = "Dagger", RequiredLevel = 1, Slot = Slot.Weapon, WeaponType = WeaponType.Dagger, WeaponDamage = 12 };

      
        // Attempt to equip weapons to heroes
        wizard.Equip(staff); // This should equip the staff to the wizard
        archer.Equip(bow);   // This should equip the bow to the archer
        swashbuckler.Equip(sword); // This should equip the sword to the swashbuckler
        barbarian.Equip(dagger); // This should equip the dagger to the barbarian

        // Equip armor
        IItem mailArmor = new Armor { Name = "Mail Armor", RequiredLevel = 1, Slot = Slot.Body, ArmorType = ArmorType.Mail, ArmorAttribute = new HeroAttribute(10, 0, 0) };
        IItem leatherArmor = new Armor { Name = "Leather Armor", RequiredLevel = 1, Slot = Slot.Body, ArmorType = ArmorType.Leather, ArmorAttribute = new HeroAttribute(5, 5, 0) };

        // Attempt to equip armor to heroes
        archer.Equip(leatherArmor); // This should equip the leather armor to the archer

        // Display hero information
        Console.WriteLine(wizard.Display());
        Console.WriteLine(archer.Display());
        Console.WriteLine(swashbuckler.Display());
        Console.WriteLine(barbarian.Display());
    }
}