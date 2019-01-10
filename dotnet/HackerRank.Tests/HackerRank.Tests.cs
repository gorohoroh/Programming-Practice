using System.Linq;
using Xunit;

namespace HackerRank.Tests
{
    public class SimpleArraySum
    {
        private class SimpleArraySumImpl
        {
            internal static int SimpleArraySum(int[] ar) => ar.Sum();
        }
        
        [Fact]
        public void SimpleArraySumTest()
        {
            var input = new[] {1, 2, 3, 4, 5, 6};

            var result = SimpleArraySumImpl.SimpleArraySum(input);
            
            Assert.Equal(21, result);
        }
    }
}

