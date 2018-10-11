namespace Evolve.NET.Core
{
    public interface IPopulation<T>
    {
        IChromosome<T> this[int index] { get; set; }

        int Generation { get; }

        int Count { get; }

        void AddChromosomeInNewPopulation(IChromosome<T> chromosome);

        bool IsFullNewGeneration { get; }

        void SwapGeneration();

        void Evaluate(IFitness<T> fitnessFunction);

        void Elite(int elitismNumber);

        void Save(string filename, bool append);
    }
}
