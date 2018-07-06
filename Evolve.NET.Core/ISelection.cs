namespace Evolve.NET.Core
{
    public interface ISelection
    {
        IChromosome Select(IPopulation population);
    }
}
