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
            Rocket r = new(RocketType.Soyuz);
            Rocket r2 = new(RocketType.Soyuz);

            Spacecraft c = new(new List<Rocket> { r, r2 }, 8);

            Console.WriteLine(c);

            c.UseRockets(new List<Rocket> { r });

            Console.WriteLine(c);

            c.ResetRockets(new List<Rocket> { r });

            Console.WriteLine(c);

            List<int> maneuvers = new() { 3, 5 };

            bool result = Evaluate(c, maneuvers, 0);

            Console.WriteLine("Spacecraft " + c + " can do maneuver: " + result);

            // To Mercury
            Rocket j = new(RocketType.Juno);
            Rocket a = new(RocketType.Atlas);
            Rocket y = new(RocketType.Soyuz);
            Rocket s = new(RocketType.Saturn);

            List<int> to_mercury = new() { 3, 5, 3, 5, 2, 2 };
            Spacecraft m = new(new List<Rocket> { j, j, j, a, a, y, y, y, y, y, y, y }, 1);

            Console.WriteLine("To Mercury " + m + " can do: " + Evaluate(m, to_mercury, 0));
        }

        static bool Evaluate(Spacecraft s, List<int> maneuvers, int maneuver_index)
        {
            if (maneuver_index >= maneuvers.Count)
            {
                return true;
            }

            int difficulty = maneuvers[maneuver_index] * s.RocketMass();

            if (difficulty > s.RocketThrust())
            {
                return false;
            }

            List<Rocket> available_rockets = s.GetAvailableRockets();

            for (int mask = 1; mask <= (1 << available_rockets.Count) - 1; mask++)
            {
                List<Rocket> subset = GetRocketSubset(available_rockets, mask);
                int thrust = GetRocketThrust(subset);

                if (thrust < difficulty)
                {
                    continue;
                }

                s.UseRockets(subset);

                bool result = Evaluate(s, maneuvers, maneuver_index + 1);

                s.ResetRockets(subset);

                if (result)
                {
                    return true;
                }
            }

            return false;
        }

        static List<Rocket> GetRocketSubset(List<Rocket> rockets, int mask)
        {
            List<Rocket> subset = new();

            int index = rockets.Count - 1;
            while (mask != 0)
            {
                bool has_rocket = (mask & 0x1) == 1;

                if ((mask & 0x1) == 1)
                {
                    subset.Add(rockets[index]);
                }

                mask /= 2;
                index--;
            }

            subset.Reverse();

            return subset;
        }

        static int GetRocketThrust(List<Rocket> rockets)
        {
            int sum = 0;

            foreach (Rocket r in rockets)
            {
                sum += r.Thrust;
            }

            return sum;
        }
    }
}