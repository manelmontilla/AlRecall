using System;
using System.Collections;
using Alrecall.Structures.Arrays.Utils;
using Xunit;

namespace  test.Alrecall
{
    public class TestArraysUtil
    {
        
        [Fact]
        public void TestReverseEvenLengthArray()
        {
             int[] inArray={0,23,589,76,3,6,6,7};
             Console.WriteLine($"\n reversing array:\n {TestUtils.convertToString(inArray)}");
             inArray.Reverse();
             Assert.Equal(inArray,new int[] {7,6,6,3,76,589,23,0});          
        }
        [Fact]
        public void TestReverseOddLengthArray()
        {
             int[] inArray={0,23,589,76,3,5,6};
             Console.WriteLine($"\n reversing array:\n {TestUtils.convertToString(inArray)}");
             inArray.Reverse();
             Assert.Equal(inArray,new int[] {6,5,3,76,589,23,0});
        }
       
    }
}