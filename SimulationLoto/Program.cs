using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationLoto
{
    class Program
    {
        private static List<int> gridInput = new List<int>();
        private static int tryNumber;
        private static List<Grille> totalGrille = new List<Grille>();
        private static List<Grille> gridsWon = new List<Grille>();

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
            gridInput = ParseInput(Console.ReadLine());

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
            gridInput.ForEach(i => Console.Write("{0}\t", i));
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
            if(reussiteN != 0)
            {
                foreach(Grille grille in gridsWon)
                {
                    Console.WriteLine($"\t- Essaie {grille.index}");
                }
            }
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

                var numbersNotChoosen = grille.numbers.Except(gridInput);

                if (numbersNotChoosen.Count() == 0)
                {
                    grille.reussite = true;
                    grille.numbers.ForEach(i => Console.Write("{0}\t", i));
                    Console.Write(" REUSSITE !");
                    Console.WriteLine(" ");
                    gridsWon.Add(grille);
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
}
