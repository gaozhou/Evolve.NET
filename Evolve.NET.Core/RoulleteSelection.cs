namespace Evolve.NET.Core
{
    public class RoulleteSelectionMethod<T> : ISelection<T>
    {
        public IChromosome<T> Select(IPopulation<T> population)
        {
            IChromosome<T> chromosome = null;
            double[] probabilities = GetProbabilities(population);
            double point = RandomHelper.RandomDouble();
            double accumulation = 0.0;
            for (int i = 0; i < population.Count; i++)
            {
                accumulation += probabilities[i];
                if (point < accumulation)
                {
                    chromosome = new Chromosome<T>((Chromosome<T>)population[i]);
                    break;
                }
            }

            return chromosome;
        }

        private double[] GetProbabilities(IPopulation<T> population)
        {
            double sum = 0.0;
            for (int i = 0; i < population.Count; i++)
                sum += population[i].Fitness;

            double[] probabilities = new double[population.Count];
            for (int i = 0; i < population.Count; i++)
                probabilities[i] = population[i].Fitness / sum;

            return probabilities;
        }
    }
}
