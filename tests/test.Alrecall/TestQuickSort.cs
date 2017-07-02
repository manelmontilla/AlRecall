using System;
using Alrecall.Structures.Arrays;
using Xunit;
namespace test.Alrecall
{
    public class TestQuickSort
    {
        public TestQuickSort()
        {

        }
        [Fact]
        public void TestShortArray()
        {
            int[] inArray = { 0, 23, 589, 76, 3, 5, 6, 7 };
            Console.WriteLine($"\n running quick sort for array:\n {TestUtils.convertToString(inArray)}");
            inArray.QuickSort();
            bool isSorted = inArray.IsSorted();
            Assert.True(isSorted);
        }
        [Fact]
        public void TestWithRepsArray()
        {
            int[] inArray = { 0, 23, 8, 6, 6, 7, 7, 1, 1, 0, 3, 5, 6, 7 };
            Console.WriteLine($"\n running quick sort for array:\n {TestUtils.convertToString(inArray)}");
            inArray.QuickSort();
            bool isSorted = inArray.IsSorted();
            Assert.True(isSorted);
        }
        [Fact]
        public void TestLongArray()
        {
            int[] inArray = new int[int.MaxValue / 100];
            var rnd = new Random();
            for (int i = 0; i < inArray.Length; i++)
            {
                inArray[i] = rnd.Next(int.MaxValue);
            }
            Console.WriteLine($"\n running  quicksort for a long array of {inArray.Length} integers.{(inArray.Length * 4) / (1024 * 1024)} MB's");
            inArray.QuickSort();
            bool isSorted = inArray.IsSorted();
            Assert.True(isSorted);
        }

    }
}