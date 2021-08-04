using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketEvaluator
{
    class Spacecraft
    {
        private readonly List<Rocket> _rockets;
        private List<bool> _rocket_available;

        public Spacecraft(List<Rocket> rockets)
        {
            _rockets = rockets;
            _rocket_available = Enumerable.Repeat(true, _rockets.Count).ToList();
        }

        public bool UseRockets(List<RocketType> rockets)
        {
            var used_indexes = new List<int>();

            foreach (RocketType r in rockets)
            {
                for (int i = 0; i < _rockets.Count; i++)
                {
                    if (_rocket_available[i] && (_rockets[i].Type == r))
                    {
                        used_indexes.Add(i);
                    }
                }
            }

            if (used_indexes.Count == rockets.Count)
            {
                foreach (int index in used_indexes)
                {
                    _rocket_available[index] = false;
                }
            }

            return used_indexes.Count == rockets.Count;
        }

        public List<Rocket> GetAvailableRockets()
        {
            var available_rockets = new List<Rocket>();

            for (int i = 0; i < _rockets.Count; i++)
            {
                if (_rocket_available[i])
                {
                    available_rockets.Add(_rockets[i]);
                }
            }

            return available_rockets;
        }

        public int RocketMass()
        {
            int mass = 0;

            for (int i = 0; i < _rockets.Count; i++)
            {
                if (_rocket_available[i])
                {
                    mass += _rockets[i].Mass;
                }
            }

            return mass;
        }

        public int RocketThrust()
        {
            int thrust = 0;

            for (int i = 0; i < _rockets.Count; i++)
            {
                if (_rocket_available[i])
                {
                    thrust += _rockets[i].Thrust;
                }
            }

            return thrust;
        }

        public override string ToString()
        {
            string str = "Craft: mass: " + RocketMass() + ", thrust: " + RocketThrust() + ", [";

            for (int i = 0; i < _rockets.Count; i++)
            {
                if (_rocket_available[i])
                {
                    str += _rockets[i].Type.ShortName();
                }
            }

            str += "]";

            return str;
        }
    }
}
