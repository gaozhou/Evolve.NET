namespace Evolve.NET.Core.MutationMethods
{
    public class ResetingRandomMutationOperator<T> : IMutation<T>
    {
        private double m_MutateRate;

        public ResetingRandomMutationOperator(double mutateRate)
        {
            m_MutateRate = mutateRate;
        }

        public void Mutate(ref IChromosome<T> chromosome, int min, int max)
        {
            if (RandomHelper.RandomDouble() < m_MutateRate)
            {
                int index = RandomHelper.RandomInt(0, chromosome.Length - 1);
                chromosome[index] = (T)(object)RandomHelper.RandomInt(min, max);
            }
        }
    }
}
