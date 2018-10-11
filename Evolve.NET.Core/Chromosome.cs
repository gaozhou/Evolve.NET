using System;
using System.Text;

namespace Evolve.NET.Core
{
    public class Chromosome<T> : IChromosome<T>
    {
        #region [ Fields ]
        private T[] m_Genes;

        private double m_Fitness;

        private ISortFitnessComparer<T> m_Comparer;
        #endregion

        #region [ Indexer ]
        public T this[int index]
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

        public T[] Genes
        {
            get { return m_Genes; }
        }

        public int Length
        {
            get { return m_Genes.Length; }
        }

        public ISortFitnessComparer<T> Comparer
        {
            get { return m_Comparer; }
            set { m_Comparer = value; }
        }

        #endregion

        #region [ Constructor ]
        public Chromosome(int length, int min, int max)
        {
            m_Genes = new T[length];
            for (int i = 0; i < length; i++)
                m_Genes[i] = (T)(object)RandomHelper.RandomInt(min, max);
            //  ▲ melhorar
            m_Comparer = new SortFitnessMax<T>();
        }

        public Chromosome(T[] genes)
        {
            m_Genes = new T[genes.Length];
            Array.ConstrainedCopy(genes, 0, m_Genes, 0, genes.Length);

            m_Comparer = new SortFitnessMax<T>();
        }

        public Chromosome(Chromosome<T> chromosome)
            : this(chromosome.Genes)
        {
            m_Comparer = new SortFitnessMax<T>();
        }
        #endregion

        #region [ Methods ] 
        public void EvaluateFitness(IFitness<T> function)
        {
            m_Fitness = function.Evaluate(this);
        }
        #endregion

        #region [ Overrides ]
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            IChromosome<T> chromosome = (Chromosome<T>)obj;
            for (int i = 0; i < Length; i++)
                if (!Genes[i].Equals(chromosome[i]))
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (T alelo in m_Genes)
                    hash = hash * alelo.GetHashCode();

                return hash;
            }
        }

        public int CompareTo(IChromosome<T> other)
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

        public static bool operator ==(Chromosome<T> a, Chromosome<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Chromosome<T> a, Chromosome<T> b)
        {
            return !(a == b);
        }
        #endregion
    }
}
