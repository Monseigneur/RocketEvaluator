using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketEvaluator
{
    class Rocket
    {
        public string Name { get; }
        public int Mass { get; }
        public int Thrust { get; }
        public int Cost { get; }

        public Rocket(string name, int mass, int thrust, int cost)
        {
            Name = name;
            Mass = mass;
            Thrust = thrust;
            Cost = cost;
        }

        public override string ToString()
        {
            return "{" + Name + ": m: " + Mass + ", t: " + Thrust + ", c: " + Cost + "}";
        }
    }
}
