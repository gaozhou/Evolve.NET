using System.Collections.Generic;

namespace Evolve.NET.Core
{
    public class TournamentSelection : ISelection
    {
        private const int TOURNAMENT_SIZE = 3;

        private int m_TournamentSize;

        public TournamentSelection(int tournamentSize = TOURNAMENT_SIZE)
        {
            m_TournamentSize = tournamentSize;
        }

        public IChromosome Select(IPopulation population)
        {
            List<IChromosome> chromosomes = new List<IChromosome>();

            for (int i = 0; i < m_TournamentSize; i++)
            {
                int randomIndex = RandomHelper.RandomInt(0, population.Count - 1);
                IChromosome chromosome = new Chromosome((Chromosome)population[randomIndex]);
                chromosomes.Add(chromosome);
            }

            chromosomes.Sort();
            return chromosomes[0];
        }
    }
}