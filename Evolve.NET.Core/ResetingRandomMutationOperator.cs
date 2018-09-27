namespace Evolve.NET.Core
{
    public class ResetingRandomMutationOperator : IMutation
    {
        private double m_MutateRate;

        public ResetingRandomMutationOperator(double mutateRate)
        {
            m_MutateRate = mutateRate;
        }

        public void Mutate(ref IChromosome chromosome, int min, int max)
        {
            if (RandomHelper.RandomDouble() < m_MutateRate)
            {
                int index = RandomHelper.RandomInt(0, chromosome.Length - 1);
                chromosome[index] = RandomHelper.RandomInt(min, max);
            }
        }
    }
}
