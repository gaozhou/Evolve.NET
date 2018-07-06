namespace Evolve.NET.Core
{
    public class RoulleteSelectionMethod : ISelection
    {
        public IChromosome Select(IPopulation population)
        {
            IChromosome chromosome = null;
            double[] probabilities = GetProbabilities(population);
            double point = Helper.RandomDouble();
            double accumulation = 0.0f;
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

        private double[] GetProbabilities(IPopulation population)
        {
            double sum = 0.0f;
            for (int i = 0; i < population.Count; i++)
                sum += population[i].Fitness;

            double[] probabilities = new double[population.Count];
            for (int i = 0; i < population.Count; i++)
                probabilities[i] = population[i].Fitness / sum;

            return probabilities;
        }
    }
}
