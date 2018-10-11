namespace Evolve.NET.Core.MutationMethods
{
    public interface IMutation<T>
    {
        void Mutate(ref IChromosome<T> chromosome, int min, int max);
    }
}
