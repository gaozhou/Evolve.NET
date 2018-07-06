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
            const int POPULATION_SIZE = 100;
            const int CHROMOSOME_SIZE = 50;
            const int GENE_MIN = 0;
            const int GENE_MAX = 14;
            const int MAX_GENERATIONS = 1000;

            GeneticAlgorithm simulator = new GeneticAlgorithm();

            simulator.Selection = new RoulleteSelectionMethod();
            simulator.Crossover = new OnePointCrossoverOperator(0.8f);
            simulator.Mutation = new ResetingRandomMutationOperator(0.02f);
            simulator.Fitness = new FitnessFunction(CHROMOSOME_SIZE, GENE_MAX);
            simulator.Debug = new ConsoleDebug(GENE_MAX);

            simulator.Simulate(POPULATION_SIZE,
                               CHROMOSOME_SIZE,
                               GENE_MIN,
                               GENE_MAX,
                               MAX_GENERATIONS);

            Console.ReadKey();
        }
    }
}
