using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Game_character
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Warrior thor = new Warrior("Thor", 1, 100, 15);
            Mage merlin = new Mage("Merlin", 1, 80, 50, 20);

           //initial stateee
            Console.WriteLine("Initial Stats:");
            Console.WriteLine(thor.ToString());
            Console.WriteLine(merlin.ToString());

            Console.WriteLine("1 2 3 fight!!!!!");

            // warrior booom boom
            Console.WriteLine();
            thor.Attack();
            Console.WriteLine();
            merlin.Defend();

            //mage woosh woosh
            Console.WriteLine();
            merlin.Attack();
            Console.WriteLine();
            thor.Defend();

            
            thor.LevelUp();
            Console.WriteLine();
            // Mage woosh wooosh
            merlin.LevelUp();

            // Display updated stats
            Console.WriteLine("\nUpdated Stats:");
            Console.WriteLine(thor.ToString());
            Console.WriteLine(merlin.ToString());



            Console.ReadKey();
        }
    }

    public abstract class GameCharacter
    {
       //Don't forget to encapsulate
        private string _name;
        private int _level;
        private int _health;
        private int _mana;
        private int _strength;
        private int _intelligence;

        
        protected static readonly Random random = new Random();

  
        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public int Level
        {
            get => _level;
            protected set => _level = value > 0 ? value : throw new ArgumentException("Level must be greater than zero.");
        }

        public int Health
        {
            get => _health;
            set => _health = value >= 0 ? value : throw new ArgumentException("Health cannot be negative.");
        }

        public int Mana
        {
            get => _mana;
            set => _mana = value >= 0 ? value : throw new ArgumentException("Mana cannot be negative.");
        }

        public int Strength
        {
            get => _strength;
            set => _strength = value >= 0 ? value : throw new ArgumentException("Strength cannot be negative.");
        }

        public int Intelligence
        {
            get => _intelligence;
            set => _intelligence = value >= 0 ? value : throw new ArgumentException("Intelligence cannot be negative.");
        }

        
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

  
        public override string ToString()
        {
            return $"{Name} (Level {Level})\n" +
                   $"Health: {Health}\n" +
                   $"Mana: {Mana}\n" +
                   $"Strength: {Strength}\n" +
                   $"Intelligence: {Intelligence}\n";
        }
    }

    public class Warrior : GameCharacter
    {
        private int _armor;

        public int Armor
        {
            get => _armor;
            protected set => _armor = value >= 0 ? value : throw new ArgumentException("Armor cannot be negative.");
        }

        // Constructor
        public Warrior(string name, int level, int health, int strength)
            : base(name, level, health, 0, strength, 0)
        {
            Armor = 10; // Default armor value
        }

        public override void Attack()
        {
            int baseDamage = Strength * 2;
            bool isCritical = random.Next(100) < 20;
            int finalDamage = isCritical ? baseDamage * 2 : baseDamage;

            Console.WriteLine($"{Name} dealt {finalDamage} damage.");
            if (isCritical) Console.WriteLine("Critical Hit!");
        }

        public override void Defend()
        {
            int damageReduction = Armor / 2;
            bool isBlocked = random.Next(100) < 15;

            Console.WriteLine(isBlocked
                ? $"{Name} successfully blocked the attack."
                : $"{Name} reduced incoming damage by {damageReduction}.");
        }

        public override void LevelUp()
        {
            Level++;
            Strength += 5;
            Health += 20;
            Armor += 2;

            Console.WriteLine($"{Name} leveled up to Level {Level}!");
            Console.WriteLine($"New Stats - Strength: {Strength}, Health: {Health}, Armor: {Armor}");
        }
    }

    public class Mage : GameCharacter
    {
        private int _spellPower;

        public int SpellPower
        {
            get => _spellPower;
            protected set => _spellPower = value >= 0 ? value : throw new ArgumentException("Spell power cannot be negative.");
        }

        // Constructor
        public Mage(string name, int level, int health, int mana, int intelligence)
            : base(name, level, health, mana, 0, intelligence)
        {
            SpellPower = 10; // Default spell power value
        }

        public override void Attack()
        {
            int magicDamage = (Intelligence * 3) + SpellPower;
            bool applyBurningEffect = random.Next(100) < 25;

            Console.WriteLine($"{Name} dealt {magicDamage} magic damage.");
            if (applyBurningEffect) Console.WriteLine("Burning effect applied!");
        }

        public override void Defend()
        {
            int damageReduction = Mana / 4;
            bool canEvade = random.Next(100) < 20;

            Console.WriteLine(canEvade
                ? $"{Name} successfully evaded the attack."
                : $"{Name} reduced incoming damage by {damageReduction}.");
        }

        public override void LevelUp()
        {
            Level++;
            Intelligence += 5;
            Mana += 15;
            SpellPower += 3;

            Console.WriteLine($"{Name} leveled up to Level {Level}!");
            Console.WriteLine($"New Stats - Intelligence: {Intelligence}, Mana: {Mana}, Spell Power: {SpellPower}");
        }
    }
}
