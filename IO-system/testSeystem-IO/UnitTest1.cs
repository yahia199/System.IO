using System;
using Xunit;
using static SystemIO.Program;

namespace SystemIOTwoUnitTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("1 2 3", 6)]
        [InlineData("1 a 3", 3)]
        [InlineData("1 2", 0)]
        [InlineData("1 2 3 4", 6)]
        [InlineData("-1 2 3", -6)]
        [InlineData("-1 2 0", 0)]
        public void ChallengeOneTests(string input, int expected)
        {
            
            
            int actual = GetProduct(input);

            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 2)]
        [InlineData(new int[] { 1, 2 }, 1)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 2)]
        [InlineData(new int[] { 0, 0, 0, 0 }, 0)]
        public void ChallengeTwoTests(int[] arr, int expected)
        {
           
            
            int actual = GetAverage(arr, arr.Length);

           
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 3)]
        [InlineData(new int[] { 1, 2 }, 2)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 4)]
        [InlineData(new int[] { 0, 0, 0, 0 }, 4)]
        public void ChallengeTwoTestConfirmInput(int[] arr, int expected)
        {
            
            
            int actual = arr.Length;

            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 }, 1)]
        [InlineData(new int[] { 1, 2, 3, 4, 4 }, 4)]
        [InlineData(new int[] { 1, 1, 1, 1 }, 1)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 1)]
        [InlineData(new int[] { 1, 1, 2, 2, 3, 3, 4, 4 }, 1)]
        public void ChallengeFourTests(int[] arr, int expected)
        {
           
            int actual = GetMostFrequent(arr);

           
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 5, 25, 99, 123, 78, 96, 555, 108, 4 }, 555)]
        [InlineData(new int[] { -7, -1, -3 }, -1)]
        [InlineData(new int[] { -8, -150, -7, 4 }, 4)]
        [InlineData(new int[] { 1, 1, 1, 1 }, 1)]
        public void ChallengeFiveTests(int[] arr, int expected)
        {
           
            int actual = GetMaximum(arr);

           
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("my name is yahia khalil", new string[] { "my: 2", "name: 4", "is: 2", "yahia: 5", "khalil: 6"})]
        [InlineData("@!# $%& ((*&)", new string[] { "@!#: 3", "$%&: 3", "((*&): 5" })]
        public void ChallengeNineTests(string input, string[] expected)
        {
            
            string[] actual = SplitASentence(input);

            
            Assert.Equal(expected, actual);
        }
    }
}