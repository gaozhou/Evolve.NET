namespace Evolve.NET.Core
{
    public class RandomResettingMutationOperator : IMutation
    {
        private double m_MutateRate;

        private int m_MinValue;

        private int m_MaxValue;

        public RandomResettingMutationOperator(double mutateRate, int min, int max)
        {
            m_MutateRate = mutateRate;
            m_MinValue = min;
            m_MaxValue = max;
        }

        public void Mutate(ref IChromosome chromosome)
        {
            if (Helper.RandomDouble() < m_MutateRate)
            {
                int index = Helper.RandomInt(0, chromosome.Length - 1);
                chromosome[index] = Helper.RandomInt(m_MinValue, m_MaxValue);
            }
        }
    }
}
