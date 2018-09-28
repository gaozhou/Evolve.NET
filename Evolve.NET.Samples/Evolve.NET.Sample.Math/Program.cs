﻿using Evolve.NET.Core;
using System;

namespace Evolve.NET.Sample.Math
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int POPULATION_SIZE = 20;
            const int CHROMOSOME_SIZE = 16;
            const int GENE_MIN = 0;
            const int GENE_MAX = 1;
            const int MAX_GENERATIONS = 200;
            const int ELITIMS_NUMBER = 3;
            const int TOURNAMENT_NUMBER = 3;
            const double CROSSOVER_RATE = 0.8;
            const double MUTATION_RATE = 0.02;
            const string FILENAME = "sample_result.xls";

            GeneticAlgorithm simulator = new GeneticAlgorithm
            {
                Selection = new TournamentSelection(TOURNAMENT_NUMBER),
                Crossover = new OnePointCrossoverOperator(CROSSOVER_RATE),
                Mutation = new ResetingRandomMutationOperator(MUTATION_RATE),
                Fitness = new FitnessFunction(),
                Elitism = ELITIMS_NUMBER,
                Filename = FILENAME,
                Debug = new ConsoleDebug(),
                DebugMask = DebugMask.First | DebugMask.Step
            };

            simulator.Simulate(POPULATION_SIZE, CHROMOSOME_SIZE, GENE_MIN, GENE_MAX, MAX_GENERATIONS);

            Console.ReadKey();
        }
    }
}
