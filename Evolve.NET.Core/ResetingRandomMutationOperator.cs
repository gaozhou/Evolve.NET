namespace Evolve.NET.Core
{
    public class ResetingRandomMutationOperator : IMutation
    {
        private float m_MutateRate;

        public ResetingRandomMutationOperator(float mutateRate)
        {
            m_MutateRate = mutateRate;
        }

        public void Mutate(ref IChromosome chromosome, int min, int max)
        {
            if (Helper.RandomFloat() < m_MutateRate)
            {
                int index = Helper.RandomInt(0, chromosome.Length - 1);
                chromosome[index] = Helper.RandomInt(min, max);
            }
        }
    }
}
