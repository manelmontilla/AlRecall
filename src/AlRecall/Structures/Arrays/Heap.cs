using System;
using Alrecall.Structures.Arrays.Utils;
namespace Alrecall.Structures.Arrays
{
    
    //This is a helper class to be used in the HeapSort algorithm. 
    //It's not designed to be used as a standalone BinaryHeap implementation
    public class Heap<T>  where T:IComparable<T> 
    {
        public T[] Array{set;get;}
        Func<T,T,bool> Comparer{get;}
     
        public Heap(T[] Array,int Length,Func<T,T,bool> Comparer=null)
        {
           if(Array==null)
                throw new ArgumentException("Array can't be null");
            
            if(Comparer==null)
             {
               //Default comparer defines a MinHeap
                Comparer=(v1,v2)=>{
                    var ret=(v1.CompareTo(v2)>0);
                    return(ret);
                };   
             }
            this.Comparer=Comparer;
            this.Array=Array;
            Heapify();
        }
        public Heap(int Length,Func<T,T,bool> Comparer=null)
        {
            this.Array=new T[Length];
            if(Comparer==null)
             {
               //Default comparer defines a MinHeap
                Comparer=(v1,v2)=>{
                    var ret=(v1.CompareTo(v2)>0);
                    return(ret);
                };   
             }
            this.Comparer=Comparer;
            this.Array=Array;
           
        }
        
        
        public  void Heapify()
        {
            if(Array.Length<=1)
                    return;
           for(int i=(Array.Length-2)/2;i>=0;i--)
           {
            PercolateDown(i,Array.Length);    
           }
             
        }
        public void PercolateUp(int pos)
        {
            //direct case
            if(pos==0)
                return;
            var paretIndex=GetParentIndex(pos);
            //direct case
            if(this.Comparer(this.Array[paretIndex],this.Array[pos]))
                return;
             this.Array.SwapValues(pos,paretIndex);   
            PercolateUp(paretIndex);
        }
        
        public void PercolateDown(int pos,int length)
        {
            
             var LeftChildIndex=GetLeftChildIndex(pos);
             if(LeftChildIndex>=length)
                return;
              int aux=LeftChildIndex;
              var RightChildIndex=LeftChildIndex+1;
              if(RightChildIndex<length && !Comparer(Array[LeftChildIndex],Array[RightChildIndex]))
                    aux=RightChildIndex;
                    
              if(this.Comparer(this.Array[pos],this.Array[aux]))
                return;
             this.Array.SwapValues(pos,aux);   
             PercolateDown(aux,length);
        }
        
       
        public int GetParentIndex(int NodeIndex)
        {
            
            if(NodeIndex<1)
                    return(-1);
            var parentIndex=(NodeIndex-1)<=2?0:(NodeIndex-1)/2;    
           
            return(parentIndex);
        }
        
        public int GetLeftChildIndex(int pos)
        {
            return(2*pos+1);
        }
        public int GetRightChildIndex(int pos)
        {
            return(2*pos+2);
        }
    }


}