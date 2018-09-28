using System;
using System.Text;

namespace Evolve.NET.Core
{
    public class Chromosome : IChromosome
    {
        #region [ Fields ]
        private int[] m_Genes;

        private double m_Fitness;

        private ISortFitnessComparer m_Comparer;
        #endregion

        #region [ Indexer ]
        public int this[int index]
        {
            get { return m_Genes[index]; }
            set { m_Genes[index] = value; }
        }
        #endregion

        #region [ Properties ]
        public double Fitness
        {
            get { return m_Fitness; }
        }

        public int[] Genes
        {
            get { return m_Genes; }
        }

        public int Length
        {
            get { return m_Genes.Length; }
        }

        public ISortFitnessComparer Comparer
        {
            get { return m_Comparer; }
            set { m_Comparer = value; }
        }

        #endregion

        #region [ Constructor ]
        public Chromosome(int length, int min, int max)
        {
            m_Genes = new int[length];
            for (int i = 0; i < length; i++)
                m_Genes[i] = RandomHelper.RandomInt(min, max);

            m_Comparer = new SortFitnessMax();
        }

        public Chromosome(int[] genes)
        {
            m_Genes = new int[genes.Length];
            Array.ConstrainedCopy(genes, 0, m_Genes, 0, genes.Length);

            m_Comparer = new SortFitnessMax();
        }

        public Chromosome(Chromosome chromosome)
            : this(chromosome.Genes)
        {
            m_Comparer = new SortFitnessMax();
        }
        #endregion

        #region [ Methods ] 
        public void EvaluateFitness(IFitness function)
        {
            m_Fitness = function.Evaluate(this);
        }
        #endregion

        #region [ Overrides ]
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            IChromosome chromosome = (IChromosome)obj;
            for (int i = 0; i < Length; i++)
                if (Genes[i] != chromosome[i])
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (int alelo in m_Genes)
                    hash = hash * alelo.GetHashCode();

                return hash;
            }
        }

        public int CompareTo(IChromosome other)
        {
            return m_Comparer.Compare(this, other);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            Array.ForEach(m_Genes, x => builder.Append(x).Append("|"));
            builder.Remove(builder.Length -1, 1);
            builder.Append("]");
            return builder.ToString();
        }

        public static bool operator ==(Chromosome a, Chromosome b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Chromosome a, Chromosome b)
        {
            return !(a == b);
        }
        #endregion
    }
}
