using Evolve.NET.Core;

namespace Evolve.NET.Sample
{
    public class FitnessFunction : IFitness
    {
        private int area;

        public FitnessFunction(int width, int height)
        {
            area = width * height;
        }

        public float Evaluate(IChromosome chromosome)
        {
            int sum = 0;
            for (int i = 0; i < chromosome.Length; i++)
                sum += chromosome[i];

            return area - sum;
        }
    }
}
