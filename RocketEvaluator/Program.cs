﻿using System;

namespace RocketEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Rocket r = new Rocket(RocketType.Juno);
            Rocket r2 = new Rocket(RocketType.Soyuz);

            Console.WriteLine(r);
            Console.WriteLine(r2);
        }
    }
}