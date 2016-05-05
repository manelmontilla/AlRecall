using System;
using System.Text;
namespace Alrecall.Structures.Arrays
{
    public class SubArray<T> where T : IComparable<T>
    {
        public T[] BaseArray { get; }
        public int begin { get; set; }
        public int length { get; set; }
        public SubArray(T[] BaseArray, int begin, int length)
        {
            if (length - begin > BaseArray.Length)
                throw new IndexOutOfRangeException();
            this.BaseArray = BaseArray;
            this.begin = begin;
            this.length = length;
        }
        public void Split(out SubArray<T> Left, out SubArray<T> Right)
        {
            int middle = begin + (length / 2);
            Left = new SubArray<T>(this.BaseArray, begin, length / 2);
            Right = new SubArray<T>(this.BaseArray, middle, length / 2 + length % 2);
        }
        public T this[int index]
        {
            get
            {
                if (index >= length)
                    throw new IndexOutOfRangeException();
                return (BaseArray[begin + index]);
            }
            set
            {
                if (index >= length)
                    throw new IndexOutOfRangeException();
                BaseArray[begin + index] = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = 0; i < this.length; i++)
            {
                if (i > 0)
                    sb.Append(",");
                sb.Append(this[i]);
            }
            sb.Append("]");
            return (sb.ToString());

        }
        public void CopyTo(SubArray<T> dest, int begin, int length)
        {

            for (int i = begin; i < begin + length; i++)
            {
                dest.BaseArray[i] = this.BaseArray[i];
            }
        }

        public string convertToString()
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = this.begin; i < this.length; i++)
            {
                if (i > 0)
                    sb.Append(",");
                sb.Append(this.BaseArray[i]);
            }
            sb.Append("]");
            return (sb.ToString());

        }
    }

}