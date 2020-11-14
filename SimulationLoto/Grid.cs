using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLoto
{
    class Grid
    {
        public List<int> Numbers { get; private set; } = new List<int>();
        public int Index { get; private set; }

        public bool success = false;

        private static readonly Random rnd = new Random();

        public Grid(int _index)
        {
            for (int i = 0; i != 5; i++)
            {
                int r = rnd.Next(1, 49);
                while (Numbers.Contains(r))
                {
                    r = rnd.Next(1, 49);
                }
                Numbers.Add(r);
            }
            Numbers.Sort();
            Index = _index;
        }
    }
}
