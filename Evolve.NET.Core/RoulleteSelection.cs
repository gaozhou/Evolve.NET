namespace Evolve.NET.Core
{
    public class RoulleteSelectionMethod : ISelection
    {
        public IChromosome Select(IPopulation population)
        {
            IChromosome chromosome = null;
            float[] probabilities = GetProbabilities(population);
            float point = Helper.RandomFloat();
            float accumulation = 0.0f;
            for (int i = 0; i < population.Count; i++)
            {
                accumulation += probabilities[i];
                if (point < accumulation)
                {
                    chromosome = new Chromosome((Chromosome)population[i]);
                    break;
                }
            }

            return chromosome;
        }

        private float[] GetProbabilities(IPopulation population)
        {
            float sum = 0.0f;
            for (int i = 0; i < population.Count; i++)
                sum += population[i].Fitness;

            float[] probabilities = new float[population.Count];
            for (int i = 0; i < population.Count; i++)
                probabilities[i] = population[i].Fitness / sum;

            return probabilities;
        }
    }
}
