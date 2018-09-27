using Evolve.NET.Core;
using System;

namespace Evolve.NET.Sample
{
    public class FitnessFunction : IFitness
    {
        public double Evaluate(IChromosome chromosome)
        {
            return Math.Pow(ConvertArrayToDecimal(chromosome.Genes), 2);
        }

        private long ConvertArrayToDecimal(int[] genes)
        {
            long value = 0;

            for (int i = 0; i < genes.Length; i++)
            {
                long exp = genes.Length - i - 1;
                value += (long)Math.Pow(2, exp) * genes[i];
            }

            return value;
        }
    }
}
