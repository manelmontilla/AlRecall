using System;
using Alrecall.Structures.Arrays;
using System.Linq;
using System.Text;
namespace  Alrecall
{
    public class TestMergeSort
    {
        public TestMergeSort()
        {
            
        }
        public void TestOne(System.IO.TextWriter writer)
        {
             int[] inArray={0,23,589,76,3,5,6,7};
             writer.WriteLine($"\n running merge sort for array:\n {convertToString(inArray)}");
             var res=inArray.MergeSort();
              writer.WriteLine($"\noutput:\n {convertToString(res)}");
        }
        
        private string convertToString(int[] arr)
        {
            StringBuilder sb=new StringBuilder("["); 
            for(int i=0;i<arr.Length;i++)
            {
                if(i>0)
                sb.Append(",");
                sb.Append(arr[i]);
            }
            sb.Append("]");
            return(sb.ToString());
            
        }
    }
}