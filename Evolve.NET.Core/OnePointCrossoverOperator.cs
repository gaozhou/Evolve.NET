namespace Evolve.NET.Core
{
    public class OnePointCrossoverOperator : ICrossover
    {
        private double m_CrossoverRate;

        public OnePointCrossoverOperator(double croosoverRate)
        {
            m_CrossoverRate = croosoverRate;
        }

        public void Crossover(IChromosome parent1, IChromosome parent2, out IChromosome offspring1, out IChromosome offspring2)
        {
            int cutoffPoint = RandomHelper.RandomInt(0, parent1.Length - 1);
            Crossover(parent1, parent2, out offspring1, out offspring2, cutoffPoint);
        }

        public void Crossover(IChromosome parent1, IChromosome parent2, out IChromosome offspring1, out IChromosome offspring2, int cutoffPoint)
        {
            offspring1 = new Chromosome(parent1.Genes);
            offspring2 = new Chromosome(parent2.Genes);

            if (RandomHelper.RandomDouble() < m_CrossoverRate)
            {
                for (int i = 0; i < parent1.Length; i++)
                {
                    offspring1[i] = i < cutoffPoint ? parent1[i] : parent2[i];
                    offspring2[i] = i < cutoffPoint ? parent2[i] : parent1[i];
                }
            }
        }
    }
}
