namespace Evolve.NET.Core
{
    public interface IFitness
    {
        double Evaluate(IChromosome chromosome);
    }
}
