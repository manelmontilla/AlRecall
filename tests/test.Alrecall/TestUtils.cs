using System;
using System.Text;
namespace test.Alrecall
{

    public static class TestUtils
    {
        public static bool IsSorted<T>(this T[] current) where T : IComparable
        {
            if (current.Length < 2)
                return true;
            bool isSorted = true;
            for (int i = 1; i < current.Length; i++)
            {
                isSorted = isSorted && (current[i - 1].CompareTo(current[i]) <= 0);
                if (!isSorted)
                    break;
            }
            return (isSorted);
        }

        public static string convertToString(int[] arr)
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 0)
                    sb.Append(",");
                sb.Append(arr[i]);
            }
            sb.Append("]");
            return (sb.ToString());

        }
        public static string ConvertToString(this int[] arr)
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 0)
                    sb.Append(",");
                sb.Append(arr[i]);
            }
            sb.Append("]");
            return (sb.ToString());

        }

    }

}