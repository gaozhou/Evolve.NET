namespace Evolve.NET.Core
{
    public interface ISelection<T>
    {
        IChromosome<T> Select(IPopulation<T> population);
    }
}
