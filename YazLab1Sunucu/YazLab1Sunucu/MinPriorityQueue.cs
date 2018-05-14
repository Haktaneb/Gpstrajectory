using System;
using System.Collections.Generic;

namespace PriorityQueue
{
    
    public class MinPriorityQueue<T>
    {
        private List<T> dataHeap;
        private readonly Comparer<T> comp;

       
        public MinPriorityQueue() : this(Comparer<T>.Default) { }

        public MinPriorityQueue(Comparer<T> comp)
        {
            this.dataHeap = new List<T>();
            this.comp = comp;
        }

      
        public void Enqueue(T value)
        {
            this.dataHeap.Add(value);
            BubbleUp();
        }

     
        public T Dequeue()
        {
            if (this.dataHeap.Count <= 0)
            {
                throw new InvalidOperationException("Cannot Dequeue from empty queue!");
            }

            T result = dataHeap[0];
            int count = this.dataHeap.Count - 1;
            dataHeap[0] = dataHeap[count];
            dataHeap.RemoveAt(count);
            ShiftDown();

            return result;
        }

      
        private void BubbleUp()
        {
            int childIndex = dataHeap.Count - 1;

            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;

                if (comp.Compare(dataHeap[childIndex], dataHeap[parentIndex]) >= 0)
                {
                    break;
                }

                SwapAt(childIndex, parentIndex);
                childIndex = parentIndex;
            }
        }

    
        private void ShiftDown()
        {
            int count = this.dataHeap.Count - 1;
            int parentIndex = 0;

            while (true)
            {
                int childIndex = parentIndex * 2 + 1;
                if (childIndex > count)
                {
                    break;
                }

                int rightChild = childIndex + 1;
                if (rightChild <= count && comp.Compare(dataHeap[rightChild], dataHeap[childIndex]) < 0)
                {
                    childIndex = rightChild;
                }
                if (comp.Compare(dataHeap[parentIndex], dataHeap[childIndex]) <= 0)
                {
                    break;
                }

                SwapAt(parentIndex, childIndex);
                parentIndex = childIndex;
            }
        }

      
        public T Peek()
        {
            if (this.dataHeap.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T frontItem = dataHeap[0];
            return frontItem;
        }

        
        public int Count()
        {
            return dataHeap.Count;
        }

        
        public void Clear()
        {
            this.dataHeap.Clear();
        }

        
        public void CopyToArray(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array");
            }

            int length = array.Length;
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Index must be between zero and array length.");
            }
            if (length - index < this.dataHeap.Count - 1)
            {
                throw new ArgumentException("Queue is bigger than array");
            }

            T[] data = this.dataHeap.ToArray();
            Array.Copy(data, 0, array, index, data.Length);
        }

      
        public bool IsConsistent()
        {
            if (dataHeap.Count == 0)
            {
                return true;
            }

            int lastIndex = dataHeap.Count - 1;
            for (int parentIndex = 0; parentIndex < dataHeap.Count; ++parentIndex)
            {
                int leftChildIndex = 2 * parentIndex + 1;
                int rightChildIndex = 2 * parentIndex + 2;

                if (leftChildIndex <= lastIndex && comp.Compare(dataHeap[parentIndex], dataHeap[leftChildIndex]) > 0)
                {
                    return false;
                }
                if (rightChildIndex <= lastIndex && comp.Compare(dataHeap[parentIndex], dataHeap[rightChildIndex]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

       
        private void SwapAt(int first, int second)
        {
            T value = dataHeap[first];
            dataHeap[first] = dataHeap[second];
            dataHeap[second] = value;
        }

        public override string ToString()
        {
            string queueString = string.Join("\n", dataHeap.ToArray());
            return queueString;
        }
    }
}