using System;
using System.Collections.Generic;

namespace Q4
{
    public class PTuple
    {
        public long V { get; set; }
        public long U { get; set; }
        public long Po { get; set; }
    }
    public class MinHeap
    {
        private List<PTuple> heap;
        public MinHeap()
        {
            heap = new List<PTuple>();
        }
        public void Push(PTuple value)
        {
            heap.Add(value);
            int i = heap.Count - 1;
            while (i > 0 && heap[(i - 1) / 2].Po > heap[i].Po)
            {
                PTuple temp = heap[(i - 1) / 2];
                heap[(i - 1) / 2] = heap[i];
                heap[i] = temp;
                i = (i - 1) / 2;
            }
        }
       
        public PTuple Pop()
        {
            // Return a default value if the heap is empty
            if (heap.Count == 0)
            {
                PTuple r = new PTuple { U = -1, V = -1, Po = -1 };
                return r;
            }

            PTuple value = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            int i = 0;
            while (i < heap.Count)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;

                // Find the minimum of the two children
                int min = i;
                if (left < heap.Count && heap[left].Po < heap[min].Po)
                {
                    min = left;
                }
                if (right < heap.Count && heap[right].Po < heap[min].Po)
                {
                    min = right;
                }

                // If the minimum isn't the current node, swap it
                if (min != i)
                {
                    PTuple temp = heap[i];
                    heap[i] = heap[min];
                    heap[min] = temp;
                    i = min;
                }
                else
                {
                    break;
                }
            }

            return value;
        }

        public PTuple Peek()
        {
            if (heap.Count == 0)
            {
                PTuple r = new PTuple { U = -1, V = -1, Po = -1 };
                return r;
            }
            return heap[0];
        }

        public bool IsEmpty()
        {
            return heap.Count == 0;
        }

        public void Clear()
        {
            heap.Clear();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
