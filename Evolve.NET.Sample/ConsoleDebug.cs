using Evolve.NET.Core;
using System;

namespace Evolve.NET.Sample
{
    public class ConsoleDebug : IDebug
    {
        public void Log(IPopulation population)
        {
            for (int i = 0; i < population.Count; i++)
            {
                Console.Write("Generation {0}\t", population.Generation);
                Log(population[i]);
                Console.WriteLine("\tFitness {0}", population[i].Fitness);                
            }

            Console.WriteLine();
        }

        public void Log(IChromosome chromosome)
        {
            for (int i = 0; i < chromosome.Length; i++)
                Console.Write("{0}", chromosome[i]);
        }
    }
}
