using System;
using System.Collections.Generic;
namespace Alrecall.Structures.Arrays.Utils
{
    
    public static class ArrayExtenxions
    {
        public static void SwapValues<T>(this T[] src, int i, int j)
        {
            T aux = src[i];
            src[i] = src[j];
            src[j] = aux;
        }

        public static T[] DeepClone<T>(this T[] array)
        {
            T[] ret = new T[array.Length];
            array.ForAll((item, index) =>
            {
                ret[index] = item;
            });
            return (ret);
        }
        public static T[,] DeepClone<T>(this T[,] array)
        {
            T[,] ret = new T[array.GetLength(0), array.GetLength(1)];
            array.ForAll((item, i, j) =>
            {
                ret[i, j] = item;
            });
            return (ret);
        }
        public static void ForAll<T>(this T[,] array, Action<T, int, int> DoAction)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); i++)
                {
                    DoAction(array[i, j], i, j);
                }

            }
        }
        public static void ForAll<T>(this T[] array, Action<T> DoAction)
        {
            for (int i = 0; i < array.Length; i++)
            {
                DoAction(array[i]);
            }
        }
        public static void ForAll<T>(this T[] array, Action<T, int> DoAction)
        {
            for (int i = 0; i < array.Length; i++)
            {
                DoAction(array[i], i);
            }
        }
        public static K[] Map<T, K>(this T[] array, Func<T, int, K> MapFunction) 
        {
            List<K> res = new List<K>();
            for (int i = 0; i < array.Length; i++)
            {
                K item = MapFunction(array[i], i);
                res.Add(item);
                
            }

            return (res.ToArray());
        }

        public static void Reverse<T>(this T[] Arr)
        {
           
            int length=Arr.GetLength(0);
            for (int i =0; i <length/2 ; i++)
            {
                T aux=Arr[i];
                int swapPos=length-i-1;
                Arr[i]=Arr[swapPos];
                Arr[swapPos]=aux;
            }
        }
    }
}
