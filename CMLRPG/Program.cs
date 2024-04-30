using System;
using CMLRPG.Character;
using CMLRPG.Enemy;
using CMLRPG.Battle;


class Program
{
    public static void Main(string[] args)
    {


        Warrior Spieler2 = new Warrior("MyShyGuy");
        Console.WriteLine($"Name: {Spieler2.Name}");
        Console.WriteLine($"Health: {Spieler2.Health}");
        Console.WriteLine($"Attack: {Spieler2.Attack}");
        Console.WriteLine($"Defense: {Spieler2.Defense}");
        Console.WriteLine($"Typ: {Spieler2.Archetyp}");
        Console.WriteLine("");

        Slime Enemy1 = new Slime();
        Console.WriteLine($"Name: {Enemy1.Name}");
        Console.WriteLine($"Health: {Enemy1.Health}");
        Console.WriteLine($"Attack: {Enemy1.Attack}");
        Console.WriteLine($"Defense: {Enemy1.Defense}");
        Console.WriteLine($"Typ: {Enemy1.Archetyp}");
        Console.WriteLine("");

        Console.WriteLine("Ziel wird angegriffen!");
        Spieler2.AttackTarget(Spieler2, Enemy1);
        Enemy1.AttackTarget(Enemy1, Spieler2);
        Console.WriteLine("das ziel ist zu mächtig!!! renn lieber los!");
        Console.WriteLine("du rennst los");
        Spieler2.Run();
        Console.WriteLine("du bist entkommen!");
        Console.WriteLine($"dein Leben ist auf {Spieler2.Health}");
        Spieler2.Eat();
        Console.WriteLine($"dein Leben ist auf {Spieler2.Health}");

    }
}