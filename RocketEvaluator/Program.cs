using System;

/// <summary>
/// Simple program to validate rockets used in the Leaving Earth board game.
/// </summary>
namespace RocketEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Rocket r = new(RocketType.Juno);
            Rocket r2 = new(RocketType.Soyuz);

            Console.WriteLine(r);
            Console.WriteLine(r2);
        }
    }
}