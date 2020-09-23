using System;
using System.Linq;
using Xunit;

namespace Accumulate
{
    public class GenericsTests
    {
        [Fact]
        public void Test1()
        {
            var teste = new Generics<int>(5);

            Assert.Equal(5, teste.Items.Count());

            teste.Set(0, 42);

            Assert.Equal(42, teste.Get(0));
        }

        [Fact]
        public void Test2()
        {
            var teste = new Generics<string>(2);

            Assert.Equal(2, teste.Items.Count());

            teste.Set(0, "42");

            Assert.Equal("42", teste.Get(0));
        }

        [Fact]
        public void Test3()
        {
        }
    }
}
