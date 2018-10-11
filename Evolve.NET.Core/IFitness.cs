namespace Evolve.NET.Core
{
    public interface IFitness<T>
    {
        double Evaluate(IChromosome<T> chromosome);
    }
}
