using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ch.wuerth.tobias.occ.ObjectContentComparator.Test
{
    [TestClass]
    public class Tester
    {
        [TestMethod]
        public void ComparatorGetContentString()
        {
            List<Tuple<Object, String>> inputs = new List<Tuple<Object, String>>
            {
                new Tuple<Object, String>(new ExampleClass(),
                    "{\"_id\":5,\"_name\":\"Default\",\"G\":10,\"SomeTime\":\"0001-01-01T00:00:00\"}"),
                new Tuple<Object, String>("This is my String.", "\"This is my String.\""),
                new Tuple<Object, String>(1337, "1337"),
                new Tuple<Object, String>("1337", "\"1337\""),
                new Tuple<Object, String>(DateTime.MinValue, "\"0001-01-01T00:00:00\"")
            };

            foreach (Tuple<Object, String> input in inputs)
            {
                Assert.AreEqual(input.Item2, Comparator.GetContentString(input.Item1));
            }
        }

        [TestMethod]
        public void ComparatorComputeContentHash()
        {
            List<Tuple<Object, String>> inputs = new List<Tuple<Object, String>>
            {
                new Tuple<Object, String>(new ExampleClass(),
                    "wel6y4rRE+fpNcCLQAOM9D9A6OZQVDb7Fb7bBpZHOK5+KKXvji9p3LokPZ+zvMx2xOzoax0K15xm3sZRCOi7ig=="),
                new Tuple<Object, String>("This is my String.",
                    "MCfv18vve7mCH2gZzI4sQD/BOhj5ZFfEd5WDiEi/Dcz4LiwvrDhOnOYa0+IMTncp3cXgT5q2hxhOvtKfyerHYA=="),
                new Tuple<Object, String>(1337,
                    "bwrGX+ARiGYKrZAL/hbFZuvw5WwKfUoVvYMQSRCN6AvTovvxqLkWYkM6QEWOwgiiB8qwc/GQvWW4ieleT8qOCQ=="),
                new Tuple<Object, String>("1337",
                    "FEbZUAIL2RC/ChNoEisBIehKUnj+Ttaa7OYSL8/fREMe0KtKYBK8DjwlO4Zt8aOMvNNoYvk9b7jvyeAGWUfILQ=="),
                new Tuple<Object, String>(DateTime.MinValue,
                    "Nftww8LP6xU0jSNlEPgd5LE9PO8gPl6Jy5sBTcl1PVocAAy/IDMzCbXgxGv1YWIPgGlPcyxfw6D8t4u7qHWqWQ==")
            };

            foreach (Tuple<Object, String> input in inputs)
            {
                Assert.AreEqual(input.Item2, Comparator.ComputeContentHash(input.Item1));
            }
        }

        [TestMethod]
        public void ComparatorAreEqual()
        {
            List<Tuple<Object, Object>> inputsAreEqual = new List<Tuple<Object, Object>>
            {
                new Tuple<Object, Object>(new ExampleClass(), new ExampleClass()),
                new Tuple<Object, Object>("This is my String.", "This is my String."),
                new Tuple<Object, Object>(1337, 1337),
                new Tuple<Object, Object>("1337", "1337"),
                new Tuple<Object, Object>(DateTime.MinValue, DateTime.MinValue),
                new Tuple<Object, Object>(DateTime.MinValue, DateTime.Parse("01/01/0001 00:00:00"))
            };

            foreach (Tuple<Object, Object> input in inputsAreEqual)
            {
                Assert.IsTrue(Comparator.AreEqual(input.Item1, input.Item2));
                Assert.IsTrue(Comparator.AreEqual(input.Item2, input.Item1));
            }

            List<Tuple<Object, Object>> inputAreNotEqual = new List<Tuple<Object, Object>>
            {
                new Tuple<Object, Object>(new ExampleClass(), new ExampleClass(1)),
                new Tuple<Object, Object>("This is my String.", "This is my string."),
                new Tuple<Object, Object>(1337, "1337"),
                new Tuple<Object, Object>("1337", 1337.0),
                new Tuple<Object, Object>(DateTime.MinValue, DateTime.Now)
            };

            foreach (Tuple<Object, Object> input in inputAreNotEqual)
            {
                Assert.IsFalse(Comparator.AreEqual(input.Item1, input.Item2));
                Assert.IsFalse(Comparator.AreEqual(input.Item2, input.Item1));
            }
        }

        private class ExampleClass
        {
            [JsonProperty] public const Int64 G = 10;
            [JsonProperty] private Int32 _id = 5;
            [JsonProperty] private String _name = "Default";
            public ExampleClass() { }

            public ExampleClass(Int32 id)
            {
                _id = id;
            }

            [JsonProperty]
            public DateTime SomeTime { get; set; }
        }
    }
}