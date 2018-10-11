using System;

namespace Evolve.NET.Core
{
    public interface IChromosome<T> : IComparable<IChromosome<T>>
    {
        T this[int index] { get; set; }

        T[] Genes { get; }

        int Length { get; }

        double Fitness { get; }

        ISortFitnessComparer<T> Comparer { get; set; }

        void EvaluateFitness(IFitness<T> function);
    }
}
