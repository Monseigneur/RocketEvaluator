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
        private int _base_mass;

        public Spacecraft(List<Rocket> rockets, int base_mass)
        {
            _rockets = rockets;
            _rocket_available = Enumerable.Repeat(true, _rockets.Count).ToList();
            _base_mass = base_mass;
        }

        public bool UseRockets(List<Rocket> rockets)
        {
            return ChangeRocketState(rockets, false);
        }

        public bool ResetRockets(List<Rocket> rockets)
        {
            return ChangeRocketState(rockets, true);
        }

        private bool ChangeRocketState(List<Rocket> rockets, bool new_state)
        {
            var changed_indexes = new List<int>();

            foreach (Rocket r in rockets)
            {
                for (int i = 0; i < _rockets.Count; i++)
                {
                    if ((_rocket_available[i] != new_state) && (_rockets[i].Type == r.Type))
                    {
                        changed_indexes.Add(i);

                        break;
                    }
                }
            }

            if (changed_indexes.Count == rockets.Count)
            {
                foreach (int index in changed_indexes)
                {
                    _rocket_available[index] = new_state;
                }
            }

            return changed_indexes.Count == rockets.Count;
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
            int mass = _base_mass;

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
            string str = "Craft: mass: " + RocketMass() + " (base: " + _base_mass + "), thrust: " + RocketThrust() + ", [";

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
