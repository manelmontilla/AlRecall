using System;
using System.Text;
namespace  Alrecall.Structures.Arrays
{
    public static class Sorts
    {
        
        public static T[] MergeSort<T>(this T[] src,Action<T[]> Step=null) where T:IComparable<T>
        {
           T[] ret=new T[src.Length];
           var subRet=new SubArray<T>(ret,0,0);
           SubArray<T> initialArray=new SubArray<T>(src,0,src.Length);
           MergeSort(initialArray,subRet,Step);
           return(subRet.BaseArray);
        }     
        
        public static void MergeSort<T>(SubArray<T> Array, SubArray<T> Result,Action<T[]> Step) where T:IComparable<T>
        {
           if(Array.length<2)
                return;
             SubArray<T> left,right;
             Array.Split(out left,out right);
             MergeSort(left,Result,Step);
             MergeSort(right,Result,Step);
             int i=0;
             int j=0;
             Result=new SubArray<T>(Result.BaseArray,left.begin,left.length+right.length);
             int rindex=0;
             while(i<left.length || j<right.length)
             {
                T val;
                 if(i>=left.length)
                  {
                    val=right[j];
                    j++;
                  }
                  else{ 
                    if(j<right.length) 
                    {
                      int comp=left[i].CompareTo(right[j]);
                      if(comp<=0)
                        {
                            val=left[i];
                            i++;
                        } 
                       else
                       {
                          val=right[j];
                          j++;
                       }
                    }
                    else
                    {
                        val=left[i];
                        i++;
                    }  
                  }
                
                Result[rindex]=val;
                rindex++;
             }
            Result.CopyTo(Array,left.begin,left.length+right.length);
        }
        public class SubArray<T> where T:IComparable<T>
        {
            public T[] BaseArray{ get ;} 
            public int begin{get;set;}
            public int length{get;set;}
            public  SubArray(T[] BaseArray,int begin,int length)
            {
                if(begin+length>BaseArray.Length)
                    throw new IndexOutOfRangeException();
               this.BaseArray=BaseArray;
               this.begin=begin;
               this.length=length;
            }
            public  void Split( out SubArray<T> Left, out SubArray<T> Right)
            {
                int middle=begin+(length/2);
                Left=new SubArray<T>(this.BaseArray,begin,length/2);
                Right=new SubArray<T>(this.BaseArray,middle,length/2+length%2);
            }
            public T this [int index] {
                get {
                    if(index>=length)
                        throw new IndexOutOfRangeException();
                      return(BaseArray[begin+index]);  
                }
                set {
                    if(index>=length)
                        throw new IndexOutOfRangeException();           
                     BaseArray[begin+index]=value;   
                }
            }
            public override string ToString()
            {
                StringBuilder sb=new StringBuilder("["); 
                for(int i=0;i<this.length;i++)
                {
                    if(i>0)
                        sb.Append(",");
                    sb.Append(this[i]);
                }
                sb.Append("]");
                return(sb.ToString());
                
            }
            public void CopyTo(SubArray<T> dest,int begin,int length)
            {
                
                
                
                for(int i=begin;i<begin+length;i++)
                {
                    dest.BaseArray[i]=this.BaseArray[i];
                }
            }
        }
    
    } 

}