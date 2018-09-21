using Evolve.NET.Core;

namespace Evolve.NET.Sample.Math
{
    public class FitnessFunction : IFitness
    {
        public double Evaluate(IChromosome chromosome)
        {
            double x = ConvertArrayToDecimal(chromosome.Genes);
            return x * x;
        }

        private static int ConvertArrayToDecimal(int[] genes)
        {
            int value = 0;

            for (int i = 0; i < genes.Length; i++)
            {
                int exp = genes.Length - i - 1;
                value += (int)System.Math.Pow(2, exp) * genes[i];
            }

            return value;
        }
    }
}
