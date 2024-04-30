using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLRPG.Character
{
    class CharacterClass
    {
        public string Name { get; private set; }
        public string Archetyp { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public int MinHealth { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }



        public CharacterClass() 
        {
            Name = "MrNobody";
            Archetyp = "Noob";
            Health = 100;
            MaxHealth = 150;
            MinHealth = 0;
            Attack = 0;
            Defense = 0;
        }

        public CharacterClass(string Name, string Archetyp, int Health, int MaxHealth, int MinHealth, int Attack, int Defense)
        {
            this.Name = Name;
            this.Archetyp = Archetyp;
            this.Health = Health;
            this.MaxHealth = MaxHealth;
            this.MinHealth = MinHealth;
            this.Attack = Attack;
            this.Defense = Defense;
        }

        public int AttackTarget()
        {
            return Attack;
        }

        public int DefendAgainstTarget()
        {
            int BlockAttack = Defense + 10;
            return BlockAttack;
        }

        public void Run()
        {
            Health = Health - 10;
        }

        public void Eat()
        {
            Console.WriteLine("Du isst ein Brötchen aus deiner Tasche.");
            Health += 10;
        }
    }
    
    class Warrior : CharacterClass
    {
        public Warrior(string Name) : base(Name, "Melee Fighter", 150, 200, 0, 25, 35)
        {

        }
    }

    class Archer : CharacterClass
    {
        public Archer(string Name) : base(Name, "Ranged Fighter", 100, 150, 0, 35, 25)
        {

        }
    }
}
