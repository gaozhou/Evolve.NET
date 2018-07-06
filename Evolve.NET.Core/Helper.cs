using System;

namespace Evolve.NET.Core
{
    public static class Helper
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

        public static float RandomFloat()
        {
            InitializeRandom();
            return (float)m_Random.NextDouble();
        }
    }
}
