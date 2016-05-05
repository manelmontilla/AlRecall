using System;
using Alrecall.Structures.Arrays;
using Xunit;
namespace  test.Alrecall
{
    public class TestHeapSort
    {
        public TestHeapSort()
        {
            
        }
        [Fact]
        public void TestShortArray()
        {
             int[] inArray={0,23,589,0,3,5,6,7,8,34,8};
             Console.WriteLine($"\n running heap sort for array:\n {TestUtils.convertToString(inArray)}");
             inArray.HeapSort(null,(heapArr,orderedArr)=>{
                 var strHeap=heapArr.convertToString();
                 string strArr=orderedArr!=null?orderedArr.convertToString():"";
                 Console.WriteLine($"Heap {strHeap}\n Sorted Array {strArr}");
             });
             bool isSorted=inArray.IsSorted();
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
             
             Console.WriteLine($"\n running  heapsort for a long array of {inArray.Length} integers.{(inArray.Length*4)/(1024*1024)} MB's");
             inArray.HeapSort();
             bool isSorted=inArray.IsSorted();
             Assert.True(isSorted);
        }
        
        
       
    }
}