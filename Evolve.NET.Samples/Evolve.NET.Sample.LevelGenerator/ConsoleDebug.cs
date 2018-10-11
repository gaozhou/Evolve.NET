using Evolve.NET.Core;
using System;
using System.Collections.Generic;

namespace Evolve.NET.Sample.LevelGenerator
{
    public class ConsoleDebug : IDebug
    {
        private IDictionary<char, ConsoleColor> colors;

        public ConsoleDebug()
        {
            colors = new Dictionary<char, ConsoleColor>();
            colors.Add(PatternFactory.PATTERN_NONE, ConsoleColor.Blue);
            colors.Add(PatternFactory.PATTERN_GROUND, ConsoleColor.DarkGray);
            colors.Add(PatternFactory.PATTERN_BLOCK, ConsoleColor.Gray);
            colors.Add(PatternFactory.PATTERN_BLOCK_COIN, ConsoleColor.Yellow);
            colors.Add(PatternFactory.PATTERN_BLOCK_ITEM, ConsoleColor.DarkYellow);
            colors.Add(PatternFactory.PATTERN_ENEMY, ConsoleColor.Red);
        }

        public void Log(IPopulation population)
        {
            for (int i = 0; i < population.Count; i++)
            {
                Console.WriteLine("Generation {0}\tFitness {1}", population.Generation, population[i].Fitness);
                Log(population[i]);
                Console.WriteLine();
            }
        }

        public void Log(IChromosome<T> chromosome)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            //Console.WriteLine(chromosome.ToString());
            for (int i = 0; i < PatternFactory.PATTERN_LENGTH; i++)
            {
                for (int j = 0; j < chromosome.Length; j++)
                {
                    int pattern = chromosome[j];
                    char tile = PatternFactory.Patterns[pattern][i];
                    Console.BackgroundColor = colors[tile];
                    //Console.Write(tile);
                    Console.Write(" ");
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
    }
}