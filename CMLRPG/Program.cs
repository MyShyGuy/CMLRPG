using System;
using CMLRPG.Character;
using CMLRPG.Enemy;
using CMLRPG.Battle;


class Program
{
    public static void Main(string[] args)
    {
        /* Characktererstellung */
        Console.WriteLine("Hello, and Welcome to my Gatcha RPG!");
        Console.WriteLine("Please give me the name of your Hero: ");
        string? Name = "Sir ";
        bool inputvalid = false;
        do
        {
            string? inputName = Console.ReadLine();
            if (inputName != string.Empty)
            {
                Name += inputName;
                inputvalid = true;
            }
        } while (!inputvalid);

        /* Erstelle charakter und battle Objekte */
        BattleSystem Battle1 = new BattleSystem();
        CharacterClass char1 = new CharacterClass(Name, "Knight", "M");
        EnemyClass Enemy = new EnemyClass();
        Console.WriteLine("heres your first test battle:");
        Console.ReadKey();

        int battleResult = Battle1.startFightSystem(char1, Enemy);

        Console.WriteLine(battleResult);
    }
}