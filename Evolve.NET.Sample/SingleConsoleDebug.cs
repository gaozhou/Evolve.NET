using Evolve.NET.Core;
using System;

namespace Evolve.NET.Sample
{
    public class SingleConsoleDebug : IDebug
    {
        private int m_Heigth;

        public SingleConsoleDebug(int height)
        {
            m_Heigth = height;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public void Log(IPopulation population)
        {
            Console.WriteLine("Generation {0}\t Fitness {1}", population.Generation, population[0].Fitness);
            /*
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Generation {0}\t Fitness {1}", population.Generation, population[0].Fitness);

            for (int y = 0; y < m_Heigth; y++)
            {
                for (int j = 0; j < population[0].Length; j++)
                {
                    Console.BackgroundColor = m_Heigth - y > population[0][j] ? ConsoleColor.Blue : ConsoleColor.DarkGreen;
                    Console.Write(" ");
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(" ");
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" ");
            */
        }
    }
}
