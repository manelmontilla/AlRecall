using System;
using Alrecall.Structures.Arrays;
using Alrecall.Structures.Arrays.Utils;
using Alrecall.Structures.PriorityQueues;
using Xunit;

namespace test.Alrecall
{
    public class TestBinaryHeap
    {

    public void TestInsertHeapMaintainsPriority ()
    {
            int[] input = { 8, 5, 7, 23, 4 };

            BinaryHeap<int> heap = new BinaryHeap<int> (input.Length);
            input.ForAll (item => heap.EnqueueElement (item));
            int[] output = null;
            output = input.Map<int, int> ((item, index) =>
            {
                return (heap.DequeueElement ());
            });
            bool okey = true;
            int lastItem = int.MinValue;
            output.ForAll (item =>
            {
                okey = okey && lastItem <= item;
                lastItem = item;
            });
            Assert.True (okey);
        }

    }
}