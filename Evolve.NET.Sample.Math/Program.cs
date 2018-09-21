using Evolve.NET.Core;
using System;

namespace Evolve.NET.Sample.Math
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int POPULATION_SIZE = 20;
            const int CHROMOSOME_SIZE = 22;
            const int GENE_MIN = 0;
            const int GENE_MAX = 1;
            const int MAX_GENERATIONS = 100;
            const double MUTATION_RATE = 0.01;
            const double CROSSOVER_RATE = 0.8;

            GeneticAlgorithm simulator = new GeneticAlgorithm
            {
                Population = new Population(POPULATION_SIZE, CHROMOSOME_SIZE, GENE_MIN, GENE_MAX),
                Selection = new RoulleteSelectionMethod(),
                ElitismPercentage = 0.1,
                Crossover = new SinglePointCrossoverOperator(CROSSOVER_RATE),
                Mutation = new RandomResettingMutationOperator(MUTATION_RATE, GENE_MIN, GENE_MAX),
                Fitness = new FitnessFunction(),
                Debug = new ConsoleDebug()
            };

            simulator.Simulate(MAX_GENERATIONS);

            Console.ReadKey();
        }
    }
}
