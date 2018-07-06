namespace Evolve.NET.Core
{
    public interface IFitness
    {
        float Evaluate(IChromosome chromosome);
    }
}
