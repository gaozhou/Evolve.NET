namespace Evolve.NET.Core
{
    public interface IPopulation
    {
        IChromosome this[int index] { get; set; }

        int Generation { get; }

        int Count { get; }

        void AddChromosomeInNewPopulation(IChromosome chromosome);

        bool IsFullNewGeneration { get; }

        void SwapGeneration();

        void Evaluate(IFitness fitnessFunction);
    }
}
