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
            const int POPULATION_SIZE = 10;
            const int CHROMOSOME_SIZE = 16;
            const int GENE_MIN = 0;
            const int GENE_MAX = 1;
            const int MAX_GENERATIONS = 1000;
            const int ELITIMS_NUMBER = 1;
            const int TOURNAMENT_NUMBER = 3;
            const double CROSSOVER_RATE = 0.8;
            const double MUTATION_RATE = 0.02;
            const string FILENAME = "sample_result.xls";

            GeneticAlgorithm simulator = new GeneticAlgorithm();

            simulator.Selection = new TournamentSelection(TOURNAMENT_NUMBER);
            simulator.Crossover = new OnePointCrossoverOperator(CROSSOVER_RATE);
            simulator.Mutation = new ResetingRandomMutationOperator(MUTATION_RATE);
            simulator.Fitness = new FitnessFunction();

            simulator.Elitism = ELITIMS_NUMBER;
            simulator.Filename = FILENAME;

            simulator.Debug = new ConsoleDebug();

            simulator.Simulate(POPULATION_SIZE, CHROMOSOME_SIZE, GENE_MIN, GENE_MAX, MAX_GENERATIONS);

            Console.ReadKey();
        }
    }
}
