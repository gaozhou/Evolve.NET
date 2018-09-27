using System;

namespace Evolve.NET.Core
{
    public static class RandomHelper
    {
        private static readonly int RANDOM_SEED = 10;

        private static Random m_Random = null;

        private static void InitializeRandom()
        {
            if (m_Random == null)
                m_Random = new Random(RANDOM_SEED);
        }

        public static int RandomInt(int min, int max)
        {
            InitializeRandom();
            return m_Random.Next(min, max + 1);
        }

        public static double RandomDouble()
        {
            InitializeRandom();
            return m_Random.NextDouble();
        }
    }
}
