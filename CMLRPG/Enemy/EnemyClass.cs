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
    class EnemyClass
    {
        public string Name { get; private set; }
        public string Archetyp { get; private set; }
        public int Health { get; set; }
        public int MaxHealth { get; private set; }
        public int MinHealth { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }


        public EnemyClass(string Name, string Archetyp, int Health, int MaxHealth, int MinHealth, int Attack, int Defense)
        {
            this.Name = Name;
            this.Archetyp = Archetyp;
            this.Health = Health;
            this.MaxHealth = MaxHealth;
            this.MinHealth = MinHealth;
            this.Attack = Attack;
            this.Defense = Defense;
        }

        public void AttackTarget(EnemyClass enemy, CharacterClass player)
        {
            if (player.Defense >= enemy.Attack)
            {
                Console.WriteLine("Du hast eine zu gute verteidigung er macht keinen Schaden!");
            }
            else
            {
                int AtkDMG = enemy.Attack - player.Defense;
                player.Health -= AtkDMG;
                Console.WriteLine($"Du hast dem Gegner {AtkDMG} Schaden gemacht");
            }
        }
    }


    class Slime : EnemyClass
    {
        public Slime() : base("Slime", "Enemy Slime", 50, 100, 0, 1, 1)
        {

        }
    }

}
