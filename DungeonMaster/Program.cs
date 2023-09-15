using System;
using DungeonMaster.Enums;
using DungeonMaster.Heroes;
using DungeonMaster.Interfaces;
using DungeonMaster.Items;

class Program
{
    static void Main(string[] args)
    {
        // Create heroes
        Hero wizard = new Wizard("Gandalf");
        Hero archer = new Archer("Legolas");
        Hero swashbuckler = new Swashbuckler("Aragorn");
        Hero barbarian = new Barbarian("Boromir");

        // Level up heroes
        wizard.LevelUp();
        archer.LevelUp();
        swashbuckler.LevelUp();
        barbarian.LevelUp();
        wizard.LevelUp();

        // Equip weapons
        IItem staff = new Weapon("Magic Staff", 1, WeaponType.Staff, 10);
        IItem bow = new Weapon("Longbow", 1, WeaponType.Bow, 15);
        IItem sword = new Weapon("Sword", 1, WeaponType.Sword, 20);
        IItem dagger = new Weapon("Dagger", 1, WeaponType.Dagger, 12);

      
        // Attempt to equip weapons to heroes
        wizard.Equip(staff); // This should equip the staff to the wizard
        archer.Equip(bow);   // This should equip the bow to the archer
        swashbuckler.Equip(sword); // This should equip the sword to the swashbuckler
        //barbarian.Equip(dagger); // This should throw an error as the barbarian can not equip the dagger weapon

        // Equip armor
        IItem leatherArmor = new Armor("Leather Armor", 1, Slot.Body, ArmorType.Leather, new HeroAttribute(5, 5, 0));

        // Attempt to equip armor to heroes
        archer.Equip(leatherArmor); // This should equip the leather armor to the archer
        //barbarian.Equip(leatherArmor); // This should throw an error as the barbarian can not equip the leather type armor

        // Display hero information
        Console.WriteLine(wizard.Display());
        Console.WriteLine(archer.Display());
        Console.WriteLine(swashbuckler.Display());
        Console.WriteLine(barbarian.Display());
    }
}