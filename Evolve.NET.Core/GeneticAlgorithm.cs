namespace Evolve.NET.Core
{
    public class GeneticAlgorithm
    {
        private IPopulation m_Population;

        public DebugMask DebugMask { get; set; }

        public ISelection Selection { get; set; }

        public ICrossover Crossover { get; set; }

        public IMutation Mutation { get; set; }

        public IFitness Fitness { get; set; }

        public int Elitism { get; set; }

        public IDebug Debug { get; set; }

        public string Filename { get; set; }

        public GeneticAlgorithm()
        {
            DebugMask = DebugMask.None;
        }

        public void Simulate(int count, int length, int min, int max, int maxGeneration)
        {
            m_Population = new Population(count, length, min, max);
            m_Population.Evaluate(Fitness);

            m_Population.Save(Filename, false);
            if (Debug != null && (DebugMask & DebugMask.First) != 0)
                Debug.Log(m_Population);

            while (m_Population.Generation < maxGeneration)
            {
                m_Population.Elite(Elitism);

                do
                {
                    IChromosome parent1 = Selection.Select(m_Population);
                    IChromosome parent2 = Selection.Select(m_Population);

                    IChromosome offspring1, offspring2;
                    Crossover.Crossover(parent1, parent2, out offspring1, out offspring2);

                    Mutation.Mutate(ref offspring1, min, max);
                    Mutation.Mutate(ref offspring2, min, max);

                    m_Population.AddChromosomeInNewPopulation(offspring1);
                    m_Population.AddChromosomeInNewPopulation(offspring2);

                } while (!m_Population.IsFullNewGeneration);

                m_Population.SwapGeneration();
                m_Population.Evaluate(Fitness);

                m_Population.Save(Filename, true);
                if (Debug != null && (DebugMask & DebugMask.Step) != 0)
                    Debug.Log(m_Population);
            }

            if (Debug != null && (DebugMask & DebugMask.Last) != 0)
                Debug.Log(m_Population);
        }
    }
}
