namespace Evolve.NET.Core
{
    public class SortFitnessMax<T> : ISortFitnessComparer<T>
    {
        public int Compare(IChromosome<T> x, IChromosome<T> y)
        {
            if (x.Fitness > y.Fitness) return -1;
            if (x.Fitness < y.Fitness) return 1;
            return 0;
        }
    }
}
