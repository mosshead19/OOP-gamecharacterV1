using System;

public class Program
{
    public static void Main()
    {
        Warrior warrior = new Warrior("Thor",1,100,15);
        Mage mage = new Mage("Merlin", 1, 80, 50, 20);

        Console.WriteLine(warrior);
        Console.WriteLine();
        Console.WriteLine(mage);
        Console.WriteLine();
        Console.WriteLine($"Warrior {warrior.Name} attacks...");
        Console.WriteLine($"Mage {mage.Name} cast a spell...");
        Console.WriteLine();
        warrior.Attack();mage.Attack();
        Console.WriteLine();
        warrior.Defend();mage.Defend();
        Console.WriteLine();
        warrior.LevelUp();mage.LevelUp();
        Console.WriteLine();

        Console.WriteLine(warrior);Console.WriteLine(); Console.WriteLine(mage);
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

   
    public GameCharacter(string name, int level, int health, int mana, int strength, int intelligence)
    {
        Name = name;
        Level = level;
        Health = health;
        Mana = mana;
        Strength = strength;
        Intelligence = intelligence;
    }

    
    public abstract void Attack();
    public abstract void Defend();
    public abstract void LevelUp();

   
    public override string ToString()
    {
        return $"{Name} (Level {Level})\t\n" +
               $" Health: {Health}\n " +
               $"Mana: {Mana}\n " +
               $"Strength: {Strength}\n " +
               $"Intelligence: {Intelligence}";
    }
}

public class Warrior : GameCharacter
{
    public int Armor { get; set; }

   
    public Warrior(string name, int level, int health, int strength)
        : base(name, level, health, 0, strength, 0)  
    {
        Armor = 10;  
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


    public Mage(string name, int level, int health, int mana, int intelligence)
        : base(name, level, health, mana, 0, intelligence)  
    {
        SpellPower = 10; 
    }

   
    public override void Attack()
    {
        
        int CalculatemagicDamage = (Intelligence * 3) + SpellPower;
        Random BurnRate = new Random();
        bool isBurning = BurnRate.Next(100) < 25;

        Console.WriteLine(isBurning ? "\tBurn Applied!\t" : "");
        Console.WriteLine($"{Name} dealt {CalculatemagicDamage} damage.");
    }


    public override void Defend()
    {
        
        int CalculateDamageReduction = Mana / 4;
        Random EvadeRate = new Random();
        bool isEvaded = EvadeRate.Next(100) < 20;

        if (isEvaded) { Console.WriteLine($"Mage {Name} Evaded Succesfully"); }
        else { Console.WriteLine($"Mage {Name} is hit... Successfully reduced damage by: {CalculateDamageReduction}"); }
    }


    public override void LevelUp()
    {
        Level++;
        Intelligence += 5;
        Mana += 15;
        SpellPower += 3;

        Console.WriteLine("\tLEVEL UP!\t\n");
        Console.WriteLine($"Mage {Name} is now Level{Level}!\n");
        Console.WriteLine("Stats Upgrades!\n" +
                            $"Intelligence: {Intelligence}\n" +
                            $"Mana: {Mana}\n" +
                            $"Spell Power: {SpellPower}");
    }
    }

