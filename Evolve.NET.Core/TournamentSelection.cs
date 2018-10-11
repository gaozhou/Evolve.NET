using System.Collections.Generic;

namespace Evolve.NET.Core
{
    public class TournamentSelection<T> : ISelection<T>
    {
        private const int TOURNAMENT_SIZE = 3;

        private int m_TournamentSize;

        public TournamentSelection(int tournamentSize = TOURNAMENT_SIZE)
        {
            m_TournamentSize = tournamentSize;
        }

        public IChromosome<T> Select(IPopulation<T> population)
        {
            List<IChromosome<T>> chromosomes = new List<IChromosome<T>>();

            for (int i = 0; i < m_TournamentSize; i++)
            {
                int randomIndex = RandomHelper.RandomInt(0, population.Count - 1);
                IChromosome<T> chromosome = new Chromosome<T>((Chromosome<T>)population[randomIndex]);
                chromosomes.Add(chromosome);
            }

            chromosomes.Sort();
            return chromosomes[0];
        }
    }
}