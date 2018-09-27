namespace Evolve.NET.Core
{
    public interface IDebug
    {
        void Log(IPopulation population);

        void Log(IChromosome chromosome);
    }
}
