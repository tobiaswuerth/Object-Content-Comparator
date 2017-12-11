using System;
using ch.wuerth.tobias.occ.Hasher;
using ch.wuerth.tobias.occ.Hasher.sha;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.occ.ObjectContentComparator
{
    public static class Comparator
    {
        public static String GetContentString<T>(T obj) where T : class
        {
            if (null == obj)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return JsonConvert.SerializeObject(obj, Formatting.None);
        }

        public static String ComputeContentHash<T>(T obj) where T : class
        {
            if (null == obj)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            String serializedObject = GetContentString(obj);
            IHasher hasher = new Sha512Hasher();
            return hasher.Compute(serializedObject);
        }

        public static Boolean AreEqual<T>(T obj1, T obj2) where T : class
        {
            String hash1 = ComputeContentHash(obj1);
            String hash2 = ComputeContentHash(obj2);
            return hash1.Equals(hash2);
        }
    }
}