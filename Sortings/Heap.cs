using System;

namespace Sortings
{
    public class MinHeap
    {
        private int Size; 
        private static int capacity = 10;
        private int[] Heaparr=new int[capacity]; 
        private int Parentind(int index) 
        { 
            if (index <= 0)
            {
                return -1;
            }
            return index / 2; 
        }
        private int leftChildind(int index) 
        { 
            return (2 * index); 
        } 
        private int rightChildind(int index) 
        { 
            return (2 * index) + 1; 
        } 
        private int LeftChild(int index) => Heaparr[leftChildind(index)];
        private int RightChild(int index) => Heaparr[rightChildind(index)];
        private int Parent(int index) => Heaparr[Parentind(index)];
        private void swap(int fpos, int spos) 
        { 
            int tmp; 
            tmp = Heaparr[fpos]; 
            Heaparr[fpos] = Heaparr[spos]; 
            Heaparr[spos] = tmp; 
        }
        private void ExtraCapacity()
                       {
                           if (Size == capacity)
                           {
                               Array.Resize(ref Heaparr, capacity * 2);
                               capacity *= 2;
                           }
                       }
        
        public void Add(int item)
        {
            ExtraCapacity();
            Heaparr[Size] = item;		
            Size++;
            HeapifyUp();		
        }
        private void HeapifyUp()
        {
            var index = Size - 1;
            while (Parentind(index) >= 0 && Parent(index) > Heaparr[index])
            {
                swap(Parentind(index), index);
                index = Parentind(index);
            }
        }
        private void HeapifyDown()
        {
            var index = 0;
            while (leftChildind(index) < Size)
            {
                var smallerChildIndex = leftChildind(index);
                if ( rightChildind(index) < Size && RightChild(index) < LeftChild(index))
                {
                    smallerChildIndex = rightChildind(index);
                }
			
                if (Heaparr[index] < Heaparr[smallerChildIndex])
                {
                    break;
                }
                else
                {
                    swap(smallerChildIndex, index);
                    index = smallerChildIndex;
                }			
            }
        }
        private void BuildHeap(int[] arr)
        {
            Size = arr.Length-1;
            for (int i = Size/2; i >= 0; i--)
            {
                Add(i);
            }
        }
        public void RemoveMin()
        {
            if (Size == 0)
            {
                throw new Exception("Heap is empty!");
            }
            else
            {
                Heaparr[0] = Heaparr[Size - 1];
                Size--;
                if (Size > 0)
                {
                    HeapifyDown();
                }
            }
        }
        public int getMin()
        {
            return Heaparr[0];
        }
    }
    
}