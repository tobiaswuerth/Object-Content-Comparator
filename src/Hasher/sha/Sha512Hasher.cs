using System;
using System.Security.Cryptography;
using System.Text;

namespace ch.wuerth.tobias.occ.Hasher.sha
{
    public class Sha512Hasher : IHasher
    {
        /// <summary>
        ///     Computes the SHA512 hash for a given object
        /// </summary>
        /// <param name="input">Input object</param>
        /// <returns>Base64 representation of the computed hash</returns>
        public String Compute(Object input)
        {
            String sInput = input?.ToString() ?? throw new ArgumentNullException(nameof(input));
            Byte[] bInput = Encoding.UTF8.GetBytes(sInput);
            Byte[] bHash;
            using (SHA512 sm = new SHA512Managed())
            {
                bHash = sm.ComputeHash(bInput);
            }
            return Convert.ToBase64String(bHash);
        }
    }
}