namespace Evolve.NET.Core
{
    public class SinglePointCrossoverOperator : ICrossover
    {
        private double m_CrossoverRate;

        public SinglePointCrossoverOperator(double croosoverRate)
        {
            m_CrossoverRate = croosoverRate;
        }

        public void Crossover(IChromosome parent1, IChromosome parent2, out IChromosome offspring1, out IChromosome offspring2)
        {
            offspring1 = new Chromosome(parent1.Genes);
            offspring2 = new Chromosome(parent2.Genes);

            if (Helper.RandomDouble() < m_CrossoverRate)
            {
                int cutoffPoint = Helper.RandomInt(0, parent1.Length);

                for (int i = 0; i < parent1.Length; i++)
                {
                    offspring1[i] = i < cutoffPoint ? parent1[i] : parent2[i];
                    offspring2[i] = i < cutoffPoint ? parent2[i] : parent1[i];
                }
            }
        }
    }
}
