using System;
using System.Collections.Generic;

/// <summary>
/// Simple program to validate rockets used in the Leaving Earth board game.
/// </summary>
namespace RocketEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            Rocket r = new(RocketType.Juno);
            Rocket r2 = new(RocketType.Soyuz);

            Spacecraft s = new(new List<Rocket> { r, r2 });

            Console.WriteLine(s);
        }
    }
}