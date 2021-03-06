using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketEvaluator
{
    public enum RocketType
    {
        Juno,
        Atlas,
        Soyuz,
        Saturn
    }

    public static class RocketTypeExtensions
    {
        public static string ShortName(this RocketType r)
        {
            switch (r)
            {
                case RocketType.Juno:
                    return "J";
                case RocketType.Atlas:
                    return "A";
                case RocketType.Soyuz:
                    return "Y";
                case RocketType.Saturn:
                    return "S";
                default:
                    return "x";
            }
        }
    }

    class Rocket
    {
        private class RocketInfo
        {
            public int Mass { get; set; }
            public int Thrust { get; set; }
            public int Cost { get; set; }
        }

        private static readonly Dictionary<RocketType, RocketInfo> rocket_data = new()
        {
            { RocketType.Juno, new RocketInfo { Mass = 1, Thrust = 4, Cost = 1 } },
            { RocketType.Atlas, new RocketInfo { Mass = 4, Thrust = 27, Cost = 5 } },
            { RocketType.Soyuz, new RocketInfo { Mass = 9, Thrust = 80, Cost = 8 } },
            { RocketType.Saturn, new RocketInfo { Mass = 20, Thrust = 200, Cost = 15 } }
        };

        public RocketType Type { get; }
        public int Mass { get; }
        public int Thrust { get; }
        public int Cost { get; }

        public Rocket(RocketType type)
        {
            var rocket_info = rocket_data[type];

            Type = type;
            Mass = rocket_info.Mass;
            Thrust = rocket_info.Thrust;
            Cost = rocket_info.Cost;
        }

        public override string ToString()
        {
            return "{" + Type + ": Mass: " + Mass + ", Thrust: " + Thrust + ", Cost: " + Cost + "}";
        }
    }
}
