using System;
using Alrecall.Structures.Arrays;
using Xunit;
namespace  test.Alrecall
{
    public class TestMergeSort
    {
        public TestMergeSort()
        {
            
        }
        [Fact]
        public void TestShortArray()
        {
             int[] inArray={0,23,589,76,3,5,6,7};
             Console.WriteLine($"\n running merge sort for array:\n {TestUtils.convertToString(inArray)}");
             var res=inArray.MergeSort();
             bool isSorted=res.IsSorted();
             Assert.True(isSorted);
             
        }
        [Fact]
        public void TestLongArray()
        {
             int[] inArray=new int[int.MaxValue/100];
             var rnd=new Random();
             for(int i=0;i<inArray.Length;i++)
             {
                 inArray[i]=rnd.Next(int.MaxValue);
             }
             
            Console.WriteLine($"\n running merge sort for a long array of {inArray.Length} integers.{(inArray.Length*4)/(1024*1024)} MB's");
             var res=inArray.MergeSort();
             bool isSorted=res.IsSorted();
             Assert.True(isSorted);
            
        }
        
        
       
    }
}