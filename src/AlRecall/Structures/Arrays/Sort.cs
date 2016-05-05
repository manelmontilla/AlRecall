using System;
using System.Text;
using Alrecall.Structures.Arrays.Utils;

namespace Alrecall.Structures.Arrays
{

    public static class Sorts
    {
        public static void InsertionSort<T>(this T[] src) where T : IComparable
        {
            if (src == null || src.Length < 2)
                return;
            for (int i = 1; i < src.Length; i++)
            {
                if (src[i].CompareTo(src[i - 1]) < 0)
                {
                    T aux = src[i];
                    int j = i - 1;
                    bool found = false;
                    while (!found && j >= 0)
                    {
                        if (src[j].CompareTo(aux) <= 0)
                            found = true;
                        else
                        {
                            src[j + 1] = src[j];
                            j--;
                        }
                    }
                    src[j + 1] = aux;

                }
            }

        }
        public static void HeapSort<T>(this T[] src, Func<T, T, bool> comparer = null, Action<SubArray<T>, SubArray<T>> Step = null) where T : IComparable<T>
        {

            var heap = new Heap<T>(src, src.Length, comparer);
            int i = src.Length - 1;
            if (Step != null)
                Step(new SubArray<T>(src, 0, src.Length), null);
            while (i > 0)
            {
                src.SwapValues(i, 0);
                heap.PercolateDown(0, i);
                if (Step != null)
                    Step(new SubArray<T>(src, 0, i), new SubArray<T>(src, i, src.Length));
                i--;
            }
        }
        public static T[] MergeSort<T>(this T[] src, Action<T[]> Step = null) where T : IComparable<T>
        {
            T[] ret = new T[src.Length];
            var subRet = new SubArray<T>(ret, 0, 0);
            SubArray<T> initialArray = new SubArray<T>(src, 0, src.Length);
            MergeSort(initialArray, subRet, Step);
            return (subRet.BaseArray);
        }

        public static void QuickSort<T>(this T[] src, Action<T[]> Step = null) where T : IComparable<T>
        {
            src.QuickSort(0, src.Length - 1, Step);
        }
        public static void QuickSort<T>(this T[] src, int BeginIndex, int EndIndex, Action<T[]> Step = null) where T : IComparable<T>
        {
            //direct case
            if (BeginIndex >= EndIndex)
                return;
            int index = src.QuickSortPartition(BeginIndex, EndIndex, Step);
            src.QuickSort(BeginIndex, index - 1);
            src.QuickSort(index + 1, EndIndex);

        }
        public static int QuickSortPartition<T>(this T[] src, int BeginIndex, int EndIndex, Action<T[]> Step = null) where T : IComparable<T>
        {
            T pivot = src[EndIndex];
            int swapIndex = BeginIndex;
            for (int i = BeginIndex; i < EndIndex; i++)
            {
                if (src[i].CompareTo(pivot) < 0)
                {
                    T aux = src[i];
                    src[i] = src[swapIndex];
                    src[swapIndex] = aux;
                    swapIndex++;
                }
            }
            src[EndIndex] = src[swapIndex];
            src[swapIndex] = pivot;
            return (swapIndex);
        }
        public static void MergeSort<T>(SubArray<T> Array, SubArray<T> Result, Action<T[]> Step) where T : IComparable<T>
        {
            if (Array.length < 2)
                return;
            SubArray<T> left, right;
            Array.Split(out left, out right);
            MergeSort(left, Result, Step);
            MergeSort(right, Result, Step);
            int i = 0;
            int j = 0;
            Result = new SubArray<T>(Result.BaseArray, left.begin, left.length + right.length);
            int rindex = 0;
            while (i < left.length || j < right.length)
            {
                T val;
                if (i >= left.length)
                {
                    val = right[j];
                    j++;
                }
                else
                {
                    if (j < right.length)
                    {
                        int comp = left[i].CompareTo(right[j]);
                        if (comp <= 0)
                        {
                            val = left[i];
                            i++;
                        }
                        else
                        {
                            val = right[j];
                            j++;
                        }
                    }
                    else
                    {
                        val = left[i];
                        i++;
                    }
                }

                Result[rindex] = val;
                rindex++;
            }
            Result.CopyTo(Array, left.begin, left.length + right.length);
        }



       

    }

}