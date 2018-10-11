using Evolve.NET.Core;

namespace Evolve.NET.Sample.LevelGenerator
{
    public class FitnessFunction : IFitness
    {
        public double Evaluate(IChromosome<T> chromosome)
        {
            double fitness = 0;
            for (int i = 0; i < chromosome.Length; i++)
            {
                if (chromosome[i] == 0)
                    fitness += 1;
                else
                    fitness -= 1;
            }

            return fitness;
        }
    }
}
