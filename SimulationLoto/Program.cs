using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationLoto
{
    class Program
    {
        static List<int> grid = new List<int>();
        static int tryNumber;
        static List<Grille> totalGrille = new List<Grille>();

        static void Main(string[] args)
        {
            while(true)
            {
                Play();
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                }
            }

        }

        private static void Play()
        {
            Console.WriteLine("Choissisez vos chiffres :");
            grid = ParseInput(Console.ReadLine());

            Console.WriteLine("Nombre d'essaies :");
            tryNumber = Int32.Parse(Console.ReadLine());

            for (int n = 0; n != tryNumber; n++)
            {
                Console.WriteLine($"ESSAIE NUMERO {n} -----------");
                Console.WriteLine("");
                Loto();
                Console.WriteLine("");
                Console.WriteLine("------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");
            }

            Console.WriteLine($"Nombre d'essaie : {tryNumber}");
            Console.WriteLine($"Numéros choisis : ");
            grid.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine("");

            int reussiteN = 0;
            int echecN = 0;

            foreach (Grille g in totalGrille)
            {
                if (g.reussite == true)
                {
                    reussiteN++;
                }
                echecN++;
            }

            Console.WriteLine($"Nombre d'echecs : {echecN}");
            Console.WriteLine($"Nombre de reussite : {reussiteN}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void Loto()
        {
           List<Grille> essaie = new List<Grille>() { new Grille(1), new Grille(2), new Grille(3), new Grille(4), new Grille(5)};
            

           foreach(Grille grille in essaie)
           {
                totalGrille.Add(grille);

                var numbersNotChoosen = grille.numbers.Except(grid);
                if(grid.Count == 0)
                {
                    grille.reussite = true;
                    grille.numbers.ForEach(i => Console.Write("{0}\t", i));
                    Console.Write(" REUSSITE !");
                    Console.WriteLine(" ");
                }

                grille.numbers.ForEach(i => Console.Write("{0}\t", i));
                Console.WriteLine(" ");
            }

        }

        private static List<int> ParseInput(string _input)
        {
            string[] inputNumbers = (_input.Split(' '));

            int i = 0;
            List<int> list = new List<int>();

            foreach (string s in inputNumbers)
            {
                if (i > 5)
                {
                    return list;
                }
                list.Add(Int32.Parse(s));
                i++;
            }

            list.Sort();

            return list;
        }
    }

    class Grille
    {
        static Random rnd = new Random();
        int index;
        public List<int> numbers { get; private set; } = new List<int>();
        public bool reussite = false;

        public Grille(int _index)
        {
            for (int i = 0; i != 5; i++)
            {
                int r = rnd.Next(1, 49);
                while(numbers.Contains(r))
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
