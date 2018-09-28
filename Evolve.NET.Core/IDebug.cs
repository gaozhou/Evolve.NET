using System;

namespace Evolve.NET.Core
{
    public interface IDebug
    {
        void Log(IPopulation population);

        void Log(IChromosome chromosome);
    }

    [Flags]
    public enum DebugMask
    {
        None = 0,
        First = 1 << 0,
        Step = 1 << 1,
        Last = 1 << 2
    }
}
