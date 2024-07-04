using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMLRPG.Enemy;

namespace CMLRPG.Character
{
    public class CharacterClass
    {
        /* Info */
        public string? Name { get; private set; }
        public string? Archetyp { get; private set; }
        public string? Sex { get; private set; }

        /* status */
        public int Health { get; set; }
        public int MaxHealth { get; private set; }
        public int MinHealth { get; private set; }

        public int Stamina { get; set; }
        public int MaxStamina { get; private set; }
        public int MinStamina { get; private set; }

        /* Attributes aka Special */
        public int strength { get; private set; }
        public int perception { get; private set; }
        public int endurence { get; private set; }
        public int charisma { get; private set; }
        public int intelligence { get; private set; }
        public int agility { get; private set; }
        public int luck { get; private set; }

        /* Stats */
        public int Attack { get; private set; }
        public int Defense { get; set; }



        public CharacterClass()
        {
            Name = "MrNobody";
            Archetyp = "Noob";
            Sex = "N/A";

            Health = 0;
            MaxHealth = 0;
            MinHealth = 0;

            Stamina = 0;
            MaxStamina = 0;
            MinStamina = 0;

            strength = 0;
            perception = 0;
            endurence = 0;
            charisma = 0;
            intelligence = 0;
            agility = 0;
            luck = 0;

            Attack = 0;
            Defense = 0;
        }

        public CharacterClass(string Name, string Archetyp, string Sex)
        {

            this.Name = Name;
            this.Archetyp = Archetyp;
            this.Sex = Sex;

            Health = 0;
            MaxHealth = 0;
            MinHealth = 0;

            Stamina = 0;
            MaxStamina = 0;
            MinStamina = 0;

            strength = 0;
            perception = 0;
            endurence = 0;
            charisma = 0;
            intelligence = 0;
            agility = 0;
            luck = 0;

            Attack = 0;
            Defense = 0;


            for (int i = 0; i < 9; i++)
            {

                Random dice = new Random();
                int Totalstat = 0;
                int roll1 = dice.Next(50, 101); /* half star */
                Totalstat += roll1;
                if (roll1 == 100) /* 1star */
                {
                    int roll2 = dice.Next(100, 501); /* 2 star */
                    Totalstat += roll2;
                    if (roll2 == 500)
                    {
                        int roll3 = dice.Next(500, 1001); /* 3star */
                        Totalstat += roll3;
                        if (roll3 == 1000)
                        {
                            int roll4 = dice.Next(1000, 5001); /* 4star */
                            Totalstat += roll4;
                            if (roll4 == 5000)
                            {
                                int roll5 = dice.Next(5000, 10001); /* 5star */
                                Console.WriteLine("Nice a 5 Star Appeared");
                                Totalstat += roll5;
                            }
                        }
                    }
                }
                switch (i)
                {
                    case 0:
                        Health = Totalstat;
                        break;

                    case 1:
                        Stamina = Totalstat;
                        break;

                    case 2:
                        strength = Totalstat;
                        break;

                    case 3:
                        perception = Totalstat;
                        break;

                    case 4:
                        endurence = Totalstat;
                        break;

                    case 5:
                        charisma = Totalstat;
                        break;

                    case 6:
                        intelligence = Totalstat;
                        break;

                    case 7:
                        agility = Totalstat;
                        break;

                    case 8:
                        luck = Totalstat;
                        break;
                }
                Totalstat = 0;
            }
            Health += 900;
            Stamina += 900;
            MaxHealth = Health;
            MaxStamina = Stamina;

            Attack = strength * agility / 10;
            Defense = endurence * agility / 10;
        }



        public void AttackTarget(CharacterClass player, EnemyClass target)
        {
            if (target.Defense / 2 >= player.Attack)
            {
                Console.WriteLine("\nThe defence of the Enemy is to strong you won`t make any Damage!");
            }
            else
            {
                int AtkDMG = player.Attack - target.Defense / 2;
                target.Health -= AtkDMG;
                Console.WriteLine($"\nYou Attacked the Enemy and made {AtkDMG} Damage!");

                if (target.Health < 0)
                {
                    Console.WriteLine("\nThe Enemy has no HP left.");
                }
                else
                {
                    Console.WriteLine($"\nThe Enemy still has {target.Health} HP");
                }
            }
        }

        public void Run()
        {
            if (Health <= 10)
            {
                Console.WriteLine("\nYour dieing of exhaustion!");
                Health -= 10;
            }
            else
            {
                Health -= 10;
                Console.WriteLine("You ran away sucsessfully but lost 10hp in the process.");
            }
        }

        public int DefendAgainstTarget()
        {
            Console.WriteLine("Your pumping up your defence stats!");
            int BlockAttack = Defense + endurence + strength;
            return BlockAttack;
        }
    }
}

/* 
    public void Eat()
    {
        Console.WriteLine("Du isst ein Brötchen aus deiner Tasche.");
        Health += 10;
    }
}
*/

