namespace Evolve.NET.Core
{
    public interface IChromosome
    {
        int this[int index] { get; set; }

        int[] Genes { get; }

        int Length { get; }

        float Fitness { get; }

        void EvaluateFitness(IFitness function);
    }
}
