namespace Evolve.NET.Core.CrossoverMethods
{
    public class OnePointCrossoverOperator<T> : ICrossover<T>
    {
        private double m_CrossoverRate;

        public OnePointCrossoverOperator(double croosoverRate)
        {
            m_CrossoverRate = croosoverRate;
        }

        public void Crossover(IChromosome<T> parent1, IChromosome<T> parent2, out IChromosome<T> offspring1, out IChromosome<T> offspring2)
        {
            int cutoffPoint = RandomHelper.RandomInt(0, parent1.Length - 1);
            Crossover(parent1, parent2, out offspring1, out offspring2, cutoffPoint);
        }

        public void Crossover(IChromosome<T> parent1, IChromosome<T> parent2, out IChromosome<T> offspring1, out IChromosome<T> offspring2, int cutoffPoint)
        {
            offspring1 = new Chromosome<T>(parent1.Genes);
            offspring2 = new Chromosome<T>(parent2.Genes);

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
