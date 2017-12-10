using System;

namespace ch.wuerth.tobias.occ.Hasher
{
    public interface IHasher
    {
        String Compute(Object input);
    }
}