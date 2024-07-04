using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMLRPG.Character;
using CMLRPG.Enemy;

namespace CMLRPG.Battle
{
    public class BattleSystem
    {
        public int fightSystem(CharacterClass player, EnemyClass enemy)
        {
            string? inputRead;
            bool myturn = true;
            int wontfight = 0;
            do
            {
                inputRead = Console.ReadLine();
                if (inputRead != string.Empty)
                {
                    string input = inputRead.ToLower().Trim();
                    switch (input)
                    {
                        case "attack":
                            player.AttackTarget(player, enemy);
                            myturn = false;
                            wontfight = 0;
                            break;

                        case "defend":
                            player.Defense = player.DefendAgainstTarget();
                            myturn = false;
                            wontfight = 0;
                            break;

                        case "run":
                            player.Run();
                            myturn = false;
                            wontfight = 1;
                            break;

                        case "speak":
                            myturn = false;
                            wontfight = 2;
                            break;

                        default:
                            Console.WriteLine("Try to type right or nobody will understand you!");
                            wontfight = 0;
                            break;
                    }
                }
                return wontfight;
            } while (myturn);
        }

        public int startFightSystem(CharacterClass char1, EnemyClass Enemy)
        {
            int wontfight = 0;
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            BattleSystem.PLayerStatus(char1);
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            BattleSystem.EnemyStatus(Enemy);
            Console.ReadKey();
            do  /* erste versuche eines kampfsystems */
            {
                if (char1.Health <= 0)
                {
                    Console.WriteLine("You Died!");
                    wontfight = 99;
                    break;
                }
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Type now what you wanna do:\n\n \tAttack\t\tDefend\t\tRun\t\tSpeak ");
                wontfight = fightSystem(char1, Enemy);
                if (wontfight == 1)
                {
                    Console.WriteLine("Coward!");
                    return wontfight;
                }
                else if (wontfight == 2)
                {
                    Console.WriteLine("What are you gonna say?");
                    return wontfight;
                }
                Console.WriteLine("Press any button to continue.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                BattleSystem.PLayerStatus(char1);
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                BattleSystem.EnemyStatus(Enemy);
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                if (Enemy.Health > 0)
                {
                    Enemy.AttackTarget(Enemy, char1);
                }
                else
                {
                    Console.WriteLine("The Enemy was slayn.");
                    wontfight = 77;
                }
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Press any button to continue.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                BattleSystem.PLayerStatus(char1);
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                BattleSystem.EnemyStatus(Enemy);
            } while (Enemy.Health > 0);
            return wontfight;
        }

        public void StartAutoBattle(CharacterClass player, EnemyClass enemy)
        {
            bool turn = false;
            bool someoneDead = false;
            do
            {
                if (enemy.Health <= 0 || player.Health <= 0)
                {
                    if (enemy.Health <= 0)
                    {
                        Console.WriteLine("The Enemy was slayn.");
                        someoneDead = true;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("you have been Defeted.");
                        someoneDead = true;
                        continue;
                    }
                }
                if (!turn)
                {
                    player.AttackTarget(player, enemy);
                    turn = true;
                }
                else
                {
                    enemy.AttackTarget(enemy, player);
                    turn = false;
                }
            } while (!someoneDead);
        }

        public static void PLayerStatus(CharacterClass AktivCharacter)
        {
            Console.WriteLine($"""  
    Player 1:               Name:           {AktivCharacter.Name}                              
                            Type:           {AktivCharacter.Archetyp}                           
                            Health:         {AktivCharacter.Health}               
                            Stamina:        {AktivCharacter.Stamina}                   
                                          
                            Attack:         {AktivCharacter.Attack}                  
                            Defence:        {AktivCharacter.Defense}              
        _[ ]_               Strength:       {AktivCharacter.strength}                         
        (-.-)               Perception:     {AktivCharacter.perception}                    
       //[ ]\\              Endurence:      {AktivCharacter.endurence}                    
      // [ ] \\             Charisma:       {AktivCharacter.charisma}                 
        // \\               Intelligence:   {AktivCharacter.intelligence}            
       //   \\              Agility:        {AktivCharacter.agility}                   
      //     \\             Luck:           {AktivCharacter.luck}                        
    """);
        }

        public static void EnemyStatus(EnemyClass AktivEnemy)
        {
            Console.WriteLine($"""  
    Enemy 1:                                        Name:           {AktivEnemy.Name}    
        <>=======() 
       (/\___   /|\\          ()==========<>_
             \_/ | \\        //|\   ______/ \)      Health:         {AktivEnemy.Health}
               \_|  \\      // | \_/                Stamina:        {AktivEnemy.Stamina} 
                 \|\/|\_   //  /\/                  Attack:         {AktivEnemy.Attack}
                  (oo)\ \_//  /                     Defence:        {AktivEnemy.Defense}  
                 //_/\_\/ /  |                      
                @@/  |=\  \  |                      
                     \_=\_ \ |                      Strength:       {AktivEnemy.strength}   
                       \==\ \|\_                    Perception:     {AktivEnemy.perception} 
                    __(\===\(  )\                   Endurence:      {AktivEnemy.endurence} 
                   (((~) __(_/   |                  Charisma:       {AktivEnemy.charisma} 
                        (((~) \  /                  Intelligence:   {AktivEnemy.intelligence}  
                        ______/ /                   Agility:        {AktivEnemy.agility}   
                        '------'                    Luck:           {AktivEnemy.luck}  
    """);
        }
    }
}
