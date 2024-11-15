using System;

public class Program
{
    public static void Main()
    {
        Warrior warrior = new Warrior("Thor",1,100,15);

        Console.WriteLine(warrior);
        Console.WriteLine();
        Console.WriteLine($"Warrior {warrior.Name} attacks...");
        Console.WriteLine();
        warrior.Attack();
        Console.WriteLine();
        warrior.Defend();
        Console.WriteLine();
        warrior.LevelUp();
        Console.WriteLine();

        Console.WriteLine(warrior);
    }
}

public abstract class GameCharacter
{

    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }

    // Constructor
    public GameCharacter(string name, int level, int health, int mana, int strength, int intelligence)
    {
        Name = name;
        Level = level;
        Health = health;
        Mana = mana;
        Strength = strength;
        Intelligence = intelligence;
    }

    // Abstract methods
    public abstract void Attack();
    public abstract void Defend();
    public abstract void LevelUp();

    // ToString method to display character info
    public override string ToString()
    {
        return $"Warrior: {Name} (Level {Level})\t\n" +
               $" Health: {Health}\n " +
               $"Mana: {Mana}\n " +
               $"Strength: {Strength}\n " +
               $"Intelligence: {Intelligence}";
    }
}

public class Warrior : GameCharacter
{
    public int Armor { get; set; }

    // Constructor
    public Warrior(string name, int level, int health, int strength)
        : base(name, level, health, 0, strength, 0)  // No mana or intelligence for a Warrior
    {
        Armor = 10;  // Default armor value
    }

    public override void Attack()
    {
        
        int CalculateBaseDamage = Strength * 2;
        Random CritRate = new Random();
        bool isCritHit= CritRate.Next(100) < 20;
        int FinalDamage = isCritHit? CalculateBaseDamage *2: CalculateBaseDamage;
        Console.WriteLine(isCritHit ? "\tCritical Hit!\t":"");
        Console.WriteLine($"{Name} dealt {FinalDamage} damage.");
        
    }

    public override void Defend()
    {
        int CalculateDamageReduction=Armor/ 2;
        Random BlockRate= new Random();
        bool isCritHit = BlockRate.Next(100) < 15;

        if (isCritHit) { Console.WriteLine($"Warrior {Name} Blocked Succesfully"); }
        else { Console.WriteLine($"Warrior {Name} is hit... Successfully reduced damage by: {CalculateDamageReduction}"); }
    }

    public override void LevelUp()
    {
        Level++;
        Strength += 5;
        Health += 20;
        Armor += 2;

        Console.WriteLine("\tLEVEL UP!\t\n");
        Console.WriteLine($"Warrior {Name} is now Level{Level}!\n");
        Console.WriteLine("Stats Upgrades!\n"+
                            $"Strength: {Strength}\n"+
                            $"Health: {Health}\n"+
                            $"Armor: {Armor}");

    }
}

public class Mage : GameCharacter
{
    public int SpellPower { get; set; }

    // Constructor
    public Mage(string name, int level, int health, int mana, int intelligence)
        : base(name, level, health, mana, 0, intelligence)  // No strength for a Mage
    {
        SpellPower = 10;  // Default spell power value
    }

    
}

