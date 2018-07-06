using System.Collections.Generic;

namespace Evolve.NET.Core
{
    public class Population : IPopulation
    {
        private List<IChromosome> m_Chromosomes;

        private HashSet<IChromosome> m_TempChromosomes;

        public IChromosome this[int index]
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

        public void AddChromosomeInNewPopulation(IChromosome chromosome)
        {
            if (m_TempChromosomes == null)
                m_TempChromosomes = new HashSet<IChromosome>();

            if (IsFullNewGeneration)
                return;

            m_TempChromosomes.Add(chromosome);
        }

        private void Load(string fileName)
        {

        }

        private void Save()
        {

        }

        public void SwapGeneration()
        {
            Generation++;
            m_Chromosomes = new List<IChromosome>(m_TempChromosomes);
            m_TempChromosomes = null;
        }

        public void Evaluate(IFitness fitnessFunction)
        {
            foreach (IChromosome chromosome in m_Chromosomes)
                chromosome.EvaluateFitness(fitnessFunction);

            m_Chromosomes.Sort();
        }

        public Population(string fileName)
        {
            Load(fileName);
        }

        public Population(int count, int length, int min, int max)
        {
            Generation = 0;

            HashSet<IChromosome> temp = new HashSet<IChromosome>();
            while (temp.Count < count)
            {
                temp.Add(new Chromosome(length, min, max));
            }

            m_Chromosomes = new List<IChromosome>(temp);
        }
    }
}
