using Evolve.NET.Core;
using System;

namespace Evolve.NET.Sample
{
    public class ConsoleDebug : IDebug
    {
        private int m_Heigth;

        public ConsoleDebug(int height)
        {
            m_Heigth = height;
        }

        public void Log(IPopulation population)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 0; i < population.Count; i++)
            {
                Console.WriteLine("Generation {0}\t Chromosome {1}\t Fitness {2}",
                    population.Generation, i, population[i].Fitness);

                for (int y = 0; y < m_Heigth; y++)
                {
                    for (int j = 0; j < population[i].Length; j++)
                    {
                        Console.BackgroundColor = m_Heigth - y > population[i][j] ?  ConsoleColor.Blue : ConsoleColor.DarkGreen;
                        Console.Write(" ");
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                }
            }
        }
    }
}
