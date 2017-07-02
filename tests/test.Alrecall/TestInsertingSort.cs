using System;
using Alrecall.Structures.Arrays;
using Xunit;
namespace test.Alrecall
{
    public class TestInsertingSort
    {
        public TestInsertingSort()
        {

        }
        [Fact]
        public void TestShortArray()
        {
            int[] inArray = { 0, 23, 589, 76, 589, 5, 6, 7 };
            Console.WriteLine($"\n running inserting for array:\n {TestUtils.convertToString(inArray)}");
            inArray.InsertionSort();
            bool isSorted = inArray.IsSorted();
            Assert.True(isSorted);
        }
        [Fact]
        private void TestLongArray()
        {
            int[] inArray = new int[int.MaxValue / 100];
            var rnd = new Random();
            for (int i = 0; i < inArray.Length; i++)
            {
                inArray[i] = rnd.Next(int.MaxValue);
            }
            Console.WriteLine($"\n running  inserting sort for a long array of {inArray.Length} integers.{(inArray.Length * 4) / (1024 * 1024)} MB's");
            inArray.InsertionSort();
            bool isSorted = inArray.IsSorted();
            Assert.True(isSorted);
        }

    }
}