﻿namespace Evolve.NET.Core
{
    public interface IMutation
    {
        void Mutate(ref IChromosome chromosome, int min, int max);
    }
}
