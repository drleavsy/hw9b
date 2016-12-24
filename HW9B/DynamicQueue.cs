using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9B
{
    class DynamicQueue<T> : DynamicArray<T>, IMyQueue<T>
    {
        private int head;
        private int tail;
        private int QSize;
        private int maxSize;

        public DynamicQueue(int sizeQ)
        {
            head = sizeQ;
            tail = 0;
            QSize = 0;
            maxSize = sizeQ;
            linkSize = 0;
            //nodeHead.setNextNode(null);
        }

        public int Size()
        {
            return linkSize;
        }

        public bool IsFull()
        {
            if (linkSize < maxSize)  // check if the buffer is not full yet
            {
                return false;
            }
            else
            {
                //Console.WriteLine("The queue is full.");
                return true;
            }
        }

        public bool IsEmpty()
        {
            if (QSize <= maxSize && QSize > 0) // check if stack is not empty already
            {
                return false;
            }
            else
            {
                // Console.WriteLine("The queue is empty.");
                return true;
            }
        }

        public T Peek()
        {
            return TValue;
        }

        public void Enqueue(T newTop)
        {
            if (linkSize < maxSize)  // check if head index is less than the array size
            {
                head = linkSize;
                Insert(head, newTop); // adding new element
               // head++; // move "writing" index one ste forward
                QSize++; // increase the size of buffer
            }
        }

        public T Dequeue()
        {
            if (linkSize > 0) // if the tail is less than the size of array
            {
                TValue = Remove(tail);
                // remove element at the tail index (first index in the ring buffer)
                //tail++; // move tail step forward
                QSize--; // reduce the size of the buffer
            }
            return TValue;
        }

        public void Print()
        {
            int i = 0;
            int count_print = linkSize;
            if (count_print == 0) // if buffer is empty print [ ]
            {
                Console.Write("[ ]\n");
            }
            else
            {
                Console.Write("[ ");
                while (count_print > 0)
                {
                    Console.Write(Get(i).ToString());
                    if (count_print > 1)
                    {
                        Console.Write(", ");
                    }
                    i++;
                    count_print--; // reduce the size of printed array

                    if (count_print == 0)
                    {
                        Console.Write(" ]\n");
                    }
                }
            }
        }
    }
}
