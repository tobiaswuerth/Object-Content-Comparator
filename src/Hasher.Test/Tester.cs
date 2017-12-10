using System;
using System.Collections.Generic;
using ch.wuerth.tobias.occ.Hasher.sha;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ch.wuerth.tobias.occ.Hasher.Test
{
    [TestClass]
    public class Tester
    {
        [TestMethod]
        public void Sha512HasherComputeNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Sha512Hasher().Compute(null));
        }

        [TestMethod]
        public void Sha512HasherComputeSpecific()
        {
            Dictionary<Object, String> inputs = new Dictionary<Object, String>
            {
                {
                    "This is a string",
                    @"9NVNMuNSM1f/AjkD6ronIejIz8dwJmN4LLPlL68sVsACzDCWtfK234cL5mXQBA6ZY1kOsC0D0WblKZnNHEMNsQ=="
                },
                {1337, @"bwrGX+ARiGYKrZAL/hbFZuvw5WwKfUoVvYMQSRCN6AvTovvxqLkWYkM6QEWOwgiiB8qwc/GQvWW4ieleT8qOCQ=="},
                {"1337", @"bwrGX+ARiGYKrZAL/hbFZuvw5WwKfUoVvYMQSRCN6AvTovvxqLkWYkM6QEWOwgiiB8qwc/GQvWW4ieleT8qOCQ=="},
                {
                    DateTime.MinValue,
                    @"mz2wFcFqZ53f2OszoQA4W+nJZnb5yThHefv4EQ1jkGmaeO9Ad/hdHn9AdkKHAPvHZmZzVmVyr+idndQw9d3eYg=="
                }
            };

            IHasher hasher = new Sha512Hasher();
            foreach (KeyValuePair<Object, String> kv in inputs)
            {
                Assert.AreEqual(kv.Value, hasher.Compute(kv.Key));
            }
        }
    }
}