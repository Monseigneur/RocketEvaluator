using System;

namespace RocketEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Rocket r = new Rocket("Juno", 1, 4, 1);

            Console.WriteLine(r);
        }
    }
}


// Rockets      Mass    Thrust
// Juno         1       4
// Atlas        4       27
// Soyuz        9       80
// Saturn       20      200