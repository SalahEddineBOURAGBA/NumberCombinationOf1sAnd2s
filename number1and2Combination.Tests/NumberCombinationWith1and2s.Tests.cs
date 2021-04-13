using ExpectedObjects;
using System;
using System.Collections.Generic;
using Xunit;

namespace number1and2Combination.Tests
{
    public class NumberCombinationWith1and2Tests
    {
        private NumberCombinationWith1and2s _solver;
        public NumberCombinationWith1and2Tests()
        {
            _solver = new NumberCombinationWith1and2s();
        }

        [Fact]
        public void Test_1()
        {
            // 1: 1
            Assert.Equal(1, _solver.ComputeNumberOfCombinations(1));
        }

        [Fact]
        public void Test_2()
        {
            // 2: 1 1, 2
            Assert.Equal(2, _solver.ComputeNumberOfCombinations(2));
        }

        [Fact]
        public void Test_3()
        {
            // 3: 1 1 1, 1 2, 2 1
            Assert.Equal(3, _solver.ComputeNumberOfCombinations(3));
        }

        [Fact]
        public void Test_4()
        {
            // 4: 1 1 1 1, 1 2 1, 2 1 1, 1 1 2, 2 2
            Assert.Equal(5, _solver.ComputeNumberOfCombinations(4));
        }

        [Fact]
        public void Test_5()
        {
            // 5: 1 1 1 1 1, 1 2 1 1, 2 1 1 1, 1 1 2 1, 1 1 1 2, 2 2 1, 1 2 2, 2 1 2
            Assert.Equal(8, _solver.ComputeNumberOfCombinations(5));
        }

        [Fact]
        public void Test_8()
        {
            // using helper has size of 34
            Assert.Equal(34, _solver.ComputeNumberOfCombinations(8));
        }

        [Fact]
        public void Test_10()
        {
            // using helper has size of 89
            Assert.Equal(89, _solver.ComputeNumberOfCombinations(10));
        }

        [Fact]
        public void Test_26()
        {
            // using helper has size of 196418
            Assert.Equal(196418, _solver.ComputeNumberOfCombinations(26));
        }
    }
}
