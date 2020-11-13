using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationLoto
{
    class Program
    {
        private static List<int> gridInput = new List<int>();
        private static int trialsNumber;
        private static List<Grid> allPlayedGrids = new List<Grid>();
        private static List<Grid> gridsWon = new List<Grid>();

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
            Console.WriteLine("Chose 5 numbers between 1 and 49 :");
            gridInput = ParseInput(Console.ReadLine());

            Console.WriteLine("Number of trials :");
            trialsNumber = Int32.Parse(Console.ReadLine());

            for (int n = 0; n != trialsNumber; n++)
            {
                Console.WriteLine($"TRIAL NUMBER {n} -----------");
                Console.WriteLine("");
                Loto();
                Console.WriteLine("");
                Console.WriteLine("------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");
            }

            Console.WriteLine($"Total number of trials : {trialsNumber}");
            Console.WriteLine($"Choosen numbers : ");
            gridInput.ForEach(i => Console.Write("{0}\t", i));
            Console.WriteLine("");

            int reussiteN = 0;
            int echecN = 0;

            foreach (Grid g in allPlayedGrids)
            {
                if (g.success == true)
                {
                    reussiteN++;
                }
                echecN++;
            }

            Console.WriteLine($"Number of failure : {echecN}");
            Console.WriteLine($"Number of success : {reussiteN}");
            if(reussiteN != 0)
            {
                foreach(Grid grille in gridsWon)
                {
                    Console.WriteLine($"\t- Try {grille.index}");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void Loto()
        {
           List<Grid> essaie = new List<Grid>() { new Grid(1), new Grid(2), new Grid(3), new Grid(4), new Grid(5)};
            

           foreach(Grid grid in essaie)
           {
                allPlayedGrids.Add(grid);

                var numbersNotChoosen = grid.numbers.Except(gridInput);

                if (numbersNotChoosen.Count() == 0)
                {
                    grid.success = true;
                    grid.numbers.ForEach(i => Console.Write("{0}\t", i));
                    Console.Write(" SUCCESS !");
                    Console.WriteLine(" ");
                    gridsWon.Add(grid);
                }

                grid.numbers.ForEach(i => Console.Write("{0}\t", i));
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
