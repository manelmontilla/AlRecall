using System;
using System.Collections;
using System.Collections.Generic;
using Alrecall.Structures.Arrays.Utils;
namespace Alrecall.Structures.PriorityQueues
{

    //TODO:implement standard priority queues operations insert, delete, extract top priority element,
    // get top priority element
    public class BinaryHeap<T> : IPriorityQueue<T>, IEnumerable<T> where T : IComparable<T>
    {
        public T[] Array { set; get; }
        Func<T, T, bool> Comparer { get; }

        int lastElement = -1;

        public BinaryHeap(int Length, Func<T, T, bool> Comparer = null)
        {
            this.Array = new T[Length];
            if (Comparer == null)
            {
                //Default comparer defines a MinHeap
                Comparer = (v1, v2) =>
                {
                    var ret = (v1.CompareTo(v2) <= 0);
                    return (ret);
                };
            }
            this.Comparer = Comparer;
            this.Array = Array;

        }


        public void Heapify()
        {
            if (Array.Length <= 1)
                return;
            for (int i = (Array.Length - 2) / 2; i >= 0; i--)
            {
                PercolateDown(i, Array.Length);
            }

        }
        public void PercolateUp(int pos)
        {
            //direct case
            if (pos == 0)
                return;
            var paretIndex = GetParentIndex(pos);
            //direct case
            if (this.Comparer(this.Array[paretIndex], this.Array[pos]))
                return;
            this.Array.SwapValues(pos, paretIndex);
            PercolateUp(paretIndex);
        }

        public void PercolateDown(int pos, int length)
        {

            var LeftChildIndex = GetLeftChildIndex(pos);
            if (LeftChildIndex >= length)
                return;
            int aux = LeftChildIndex;
            var RightChildIndex = LeftChildIndex + 1;
            if (RightChildIndex < length && !Comparer(Array[LeftChildIndex], Array[RightChildIndex]))
                aux = RightChildIndex;

            if (this.Comparer(this.Array[pos], this.Array[aux]))
                return;
            this.Array.SwapValues(pos, aux);
            PercolateDown(aux, length);
        }


        public int GetParentIndex(int NodeIndex)
        {

            if (NodeIndex < 1)
                return (-1);
            var parentIndex = (NodeIndex - 1) <= 2 ? 0 : (NodeIndex - 1) / 2;

            return (parentIndex);
        }

        public int GetLeftChildIndex(int pos)
        {
            return (2 * pos + 1);
        }
        public int GetRightChildIndex(int pos)
        {
            return (2 * pos + 2);
        }

        public void EnqueueElement(T Element)
        {
            lastElement++;
            if (lastElement == Array.Length)
                throw new Exception("Can not Enqueue a new element.Queue is full.");
            Array[lastElement] = Element;
            PercolateUp(lastElement);
        }

        public T PeekElement()
        {
            return (Array[lastElement]);
        }

        public T DequeueElement()
        {
            if (lastElement < 0)
                throw new Exception("Can not Dequeue an element. Queue is empty");

            T ret = Array[0];
            Array[0] = Array[lastElement];
            lastElement--;
            if (lastElement > 0)
            {
                PercolateDown(0, lastElement + 1);
            };

            return (ret);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)Array).GetEnumerator();
        }
    }


}