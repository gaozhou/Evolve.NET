namespace Evolve.NET.Core
{
    public class GeneticAlgorithm
    {
        public IPopulation Population { get; set; }

        public ISelection Selection { get; set; }

        public double ElitismPercentage { get; set; }

        public ICrossover Crossover { get; set; }

        public IMutation Mutation { get; set; }

        public IFitness Fitness { get; set; }

        public IDebug Debug { get; set; }

        private void Elite()
        {
            int eliteCount = (int)(ElitismPercentage * Population.Count);
            for (int i = 0; i < eliteCount; i++)
                Population.AddChromosomeInNewPopulation(Population[i]);
        }

        public void Simulate(int maxGeneration)
        {
            Population.Evaluate(Fitness);

            if (Debug != null)
                Debug.Log(Population);

            while (Population.Generation < maxGeneration)
            {
                Elite();

                do
                {
                    IChromosome parent1 = Selection.Select(Population);
                    IChromosome parent2 = Selection.Select(Population);

                    Crossover.Crossover(parent1, parent2, out IChromosome offspring1, out IChromosome offspring2);

                    Mutation.Mutate(ref offspring1);
                    Mutation.Mutate(ref offspring2);

                    Population.AddChromosomeInNewPopulation(offspring1);
                    Population.AddChromosomeInNewPopulation(offspring2);

                } while (!Population.IsFullNewGeneration);

                Population.SwapGeneration();
                Population.Evaluate(Fitness);

                if (Debug != null)
                    Debug.Log(Population);
            }
        }
    }
}
