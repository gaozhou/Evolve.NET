using Evolve.NET.Core.CrossoverMethods;
using Evolve.NET.Core.MutationMethods;

namespace Evolve.NET.Core
{
    public class GeneticAlgorithm<T>
    {
        private IPopulation<T> m_Population;

        public DebugMask DebugMask { get; set; }

        public ISelection<T> Selection { get; set; }

        public ICrossover<T> Crossover { get; set; }

        public IMutation<T> Mutation { get; set; }

        public IFitness<T> Fitness { get; set; }

        public int Elitism { get; set; }

        public IDebug<T> Debug { get; set; }

        public string Filename { get; set; }

        public GeneticAlgorithm()
        {
            DebugMask = DebugMask.None;
        }

        public void Simulate(int count, int length, int min, int max, int maxGeneration)
        {
            m_Population = new Population<T>(count, length, min, max);
            m_Population.Evaluate(Fitness);

            m_Population.Save(Filename, false);
            if (Debug != null && (DebugMask & DebugMask.First) != 0)
                Debug.Log(m_Population);

            while (m_Population.Generation < maxGeneration)
            {
                m_Population.Elite(Elitism);

                do
                {
                    IChromosome<T> parent1 = Selection.Select(m_Population);
                    IChromosome<T> parent2 = Selection.Select(m_Population);

                    IChromosome<T> offspring1, offspring2;
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
