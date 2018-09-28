using Evolve.NET.Core;

namespace Evolve.NET.Sample.Math
{
    public class FitnessFunction : IFitness
    {
        public double Evaluate(IChromosome chromosome)
        {
            return System.Math.Pow(ConvertArrayToDecimal(chromosome.Genes), 2);
        }

        private long ConvertArrayToDecimal(int[] genes)
        {
            long value = 0;

            for (int i = 0; i < genes.Length; i++)
            {
                long exp = genes.Length - i - 1;
                value += (long)System.Math.Pow(2, exp) * genes[i];
            }

            return value;
        }
    }
}
