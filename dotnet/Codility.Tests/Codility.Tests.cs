using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Codility.Tests
{
    public class SmallestAbsentNumber
    {
        private class SmallestAbsentNumberImpl
        {
            /// <summary>
            /// Write a function that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.
            /// For example, given A = {1,3,6,4,1,2}, the function should return 5
            /// Given A = {1,2,3}, the function should return 4
            /// Given A = {-1, -3}, the function should return 1
            /// Results of this test on Codility: https://app.codility.com/demo/results/demo7F2VUK-2RR/
            /// </summary>
            internal static int SmallestPositiveIntegerNotInArray(int[] inputArray)
            {
                if (inputArray.Length < 1 || inputArray.Length > 100000) throw new NotSupportedException();

                int trackingValue = 0;
                foreach (var currentValue in inputArray.OrderBy(x => x))
                {
                    if (currentValue > trackingValue)
                    {
                        if (currentValue - trackingValue > 1) break;
                        trackingValue = currentValue;
                    }
                }

                return trackingValue+1;
            }

        }

        [Theory]
        [MemberData(nameof(SmallestAbsentNumberData))]
        public void Returns_smallest_positive_integer_above_zero_that_is_not_in_given_array(int[] array, int expectedNumber)
        {
            int actualNumber = SmallestAbsentNumberImpl.SmallestPositiveIntegerNotInArray(array);
            Assert.Equal(expectedNumber, actualNumber);
        }

        public static IEnumerable<object[]> SmallestAbsentNumberData => new List<object[]>
        {
            new object[]
            {
                new int[]{1,3,6,4,1,2},
                5
            },
            new object[]
            {
                new int[]{1,2,3},
                4
            },
            new object[]
            {
                new int[]{-1423,0,2,3,52,4,7,1},
                5
            },
            new object[]
            {
                new int[]{-1,-3},
                1
            }
        };
        
    }
}
