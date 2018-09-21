using Evolve.NET.Core;
using System;

namespace Evolve.NET.Sample.Math
{
    public class ConsoleDebug : IDebug
    {
        public void Log(IPopulation population)
        {
            Console.WriteLine("Generation {0}", population.Generation);

            for (int i = 0; i < population.Count; i++)
            {
                String chromosome = "";
                for (int j = 0; j < population[i].Genes.Length; j++)
                    chromosome += population[i][j];

                Console.WriteLine("Chromosome {0}\t Fitness {1}", chromosome, population[i].Fitness);
            }

            Console.WriteLine();
        }
    }
}
