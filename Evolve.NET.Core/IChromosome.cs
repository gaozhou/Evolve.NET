using System;

namespace Evolve.NET.Core
{
    public interface IChromosome : IComparable<IChromosome>
    {
        int this[int index] { get; set; }

        int[] Genes { get; }

        int Length { get; }

        double Fitness { get; }

        ISortFitnessComparer Comparer { get; set; }

        void EvaluateFitness(IFitness function);
    }
}
