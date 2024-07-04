using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CMLRPG.Character;

namespace CMLRPG.Enemy
{
    public class EnemyClass
    {
        string[] Names = {
        "Gustav der Grässliche",
        "Bernhard der Berserker",
        "Reinhard der Ruchlose",
        "Dieter der Dämonische",
        "Kurt der Krieger",
        "Wilhelm der Wütende",
        "Ernst der Erbarmungslose",
        "Otto der Obermacker",
        "Fritz der Furchtlose",
        "Hans der Hasserfüllte",
        "Klaus der Kalte",
        "Leopold der Lauernde",
        "Ludwig der Lästige",
        "Sigmund der Starke",
        "Ulrich der Unbarmherzige",
        "Wolfgang der Wilde"
        };

        /* Info */
        public string? Name { get; private set; }

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
        public int Defense { get; private set; }

        public EnemyClass()
        {
            Name = "Enemy";

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

            Random dice = new Random();
            int rollnames = dice.Next(0, 15);
            Name = Names[rollnames];


            for (int i = 0; i < 9; i++)
            {
                int Totalstat = 0;
                int roll1 = dice.Next(50, 101); /* half star */
                Totalstat += roll1;
                if (roll1 == 100) /* 1star */
                {
                    int roll2 = dice.Next(100, 501); /* 2 star */
                    Totalstat += roll2;
                    Name += "*";
                    if (roll2 == 500)
                    {
                        int roll3 = dice.Next(500, 1001); /* 3star */
                        Totalstat += roll3;
                        Name += "*";
                        if (roll3 == 1000)
                        {
                            int roll4 = dice.Next(1000, 5001); /* 4star */
                            Totalstat += roll4;
                            Name += "*";
                            if (roll4 == 5000)
                            {
                                int roll5 = dice.Next(5000, 10001); /* 5star */
                                Console.WriteLine("Nice a 5 Star Appeared");
                                Name += "*";
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
            Health += 1000;
            Stamina += 1000;
            MaxHealth = Health;
            MaxStamina = Stamina;

            Attack = strength * agility / 10;
            Defense = endurence * agility / 10;
        }

        public void AttackTarget(EnemyClass enemy, CharacterClass target)
        {
            if (target.Defense / 2 >= enemy.Attack)
            {
                Console.WriteLine("\nYour defence is to High the Enemy can`t Damage you!");
            }
            else
            {
                int AtkDMG = enemy.Attack - target.Defense / 2;
                target.Health -= AtkDMG;
                Console.WriteLine($"\nThe Enemy attacked you and made {AtkDMG} Damage!");
                if (target.Health < 0)
                {
                    Console.WriteLine("\nYou dont have any HP left.");
                }
                else
                {
                    Console.WriteLine($"\nYour have {target.Health} HP remaining!");
                }
            }
        }
    }
}
