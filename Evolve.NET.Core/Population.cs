using System;
using System.Collections.Generic;
using System.IO;

namespace Evolve.NET.Core
{
    public class Population<T> : IPopulation<T>
    {
        private List<IChromosome<T>> m_Chromosomes;

        private List<IChromosome<T>> m_TempChromosomes;

        public IChromosome<T> this[int index]
        {
            get { return m_Chromosomes[index]; }
            set { m_Chromosomes[index] = value; }
        }

        public int Count
        {
            get { return m_Chromosomes.Count; }
        }

        public int Generation { get; private set; }

        public bool IsFullNewGeneration
        {
            get { return m_TempChromosomes != null && m_TempChromosomes.Count == Count; }
        }

        public void AddChromosomeInNewPopulation(IChromosome<T> chromosome)
        {
            if (m_TempChromosomes == null)
                m_TempChromosomes = new List<IChromosome<T>>();

            if (IsFullNewGeneration)
                return;

            m_TempChromosomes.Add(chromosome);
        }

        private void Load(string fileName)
        {

        }

        public void Save(string filename, bool append)
        {
            using (StreamWriter outputFile = new StreamWriter(filename, append))
            {
                double best = 0;
                double average = 0;

                for (int i = 0; i < m_Chromosomes.Count; i++)
                {
                    average += m_Chromosomes[i].Fitness;

                    if (best < m_Chromosomes[i].Fitness)
                        best = m_Chromosomes[i].Fitness;
                }

                average /= (double)m_Chromosomes.Count;

                outputFile.WriteLine("{0}\t{1}", average, best);
            }
        }

        public void Elite(int elitismNumber)
        {
            if (elitismNumber <= 0)
                return;

            List<IChromosome<T>> chromosomes = new List<IChromosome<T>>(m_Chromosomes);
            chromosomes.Sort();

            for (int i = 0; i < elitismNumber; i++)
                AddChromosomeInNewPopulation(chromosomes[i]);
        }

        public void SwapGeneration()
        {
            Generation++;
            m_Chromosomes = new List<IChromosome<T>>(m_TempChromosomes);
            m_TempChromosomes = null;
        }

        public void Evaluate(IFitness<T> fitnessFunction)
        {
            foreach (IChromosome<T> chromosome in m_Chromosomes)
                chromosome.EvaluateFitness(fitnessFunction);

            //m_Chromosomes.Sort();
        }

        public Population(string fileName)
        {
            Load(fileName);
        }

        public Population(int count, int length, int min, int max)
        {
            Generation = 0;

            List<IChromosome<T>> temp = new List<IChromosome<T>>();
            while (temp.Count < count)
            {
                temp.Add(new Chromosome<T>(length, min, max));
            }

            m_Chromosomes = new List<IChromosome<T>>(temp);
        }
    }
}
