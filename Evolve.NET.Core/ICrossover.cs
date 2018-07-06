namespace Evolve.NET.Core
{
    public interface ICrossover
    {
        void Crossover(IChromosome parent1, IChromosome parent2, out IChromosome offspring1, out IChromosome offspring2);
    }
}
