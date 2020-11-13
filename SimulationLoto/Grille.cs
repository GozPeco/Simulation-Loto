using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationLoto
{
    class Grille
    {
        public List<int> numbers { get; private set; } = new List<int>();
        public bool reussite = false;
        public int index;

        private static Random rnd = new Random();

        public Grille(int _index)
        {
            for (int i = 0; i != 5; i++)
            {
                int r = rnd.Next(1, 49);
                while (numbers.Contains(r))
                {
                    r = rnd.Next(1, 49);
                }
                numbers.Add(r);
            }

            numbers.Sort();

            index = _index;
        }
    }
}
