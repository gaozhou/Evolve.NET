using Evolve.NET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolve.NET.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int POPULATION_SIZE = 200;
            const int CHROMOSOME_SIZE = 200;
            const int GENE_MIN = 0;
            const int GENE_MAX = 14;
            const int MAX_GENERATIONS = 1000;
            const double MUTATION_RATE = 0.02;
            const double CROSSOVER_RATE = 0.8;

            GeneticAlgorithm simulator = new GeneticAlgorithm
            {
                Population = new Population(POPULATION_SIZE, CHROMOSOME_SIZE, GENE_MIN, GENE_MAX),
                Selection = new RoulleteSelectionMethod(),
                ElitismPercentage = 0.1,
                Crossover = new SinglePointCrossoverOperator(CROSSOVER_RATE),
                Mutation = new RandomResettingMutationOperator(MUTATION_RATE, GENE_MIN, GENE_MAX),
                Fitness = new FitnessFunction(CHROMOSOME_SIZE, GENE_MAX),
                Debug = new SingleConsoleDebug(GENE_MAX)
            };

            simulator.Simulate(MAX_GENERATIONS);

            Console.ReadKey();
        }
    }
}




