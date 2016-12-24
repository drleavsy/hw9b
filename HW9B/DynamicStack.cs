using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9B
{
    class DynamicStack<T> : DynamicArray<T>, IMyStack<T>
    {
        private int top;
        private int stackSize;
        private int maxSize;
 
        public DynamicStack(int sizeStack)
        {
            linkSize = 0;
            top = 0;
            //nodeHead.setNextNode(null);
            stackSize = 0;
            maxSize = sizeStack;
        }

        public int Size()
        {
            return linkSize;
        }

        public bool IsFull()
        {
            if (linkSize == maxSize) //if stack is full
            {
                return true;
            }
            return false;
        }

        public bool IsEmpty()
        {
            if (linkSize == 0) // check if stack is not empty already
            {
                return true;
            }
            return false;
        }

        public T Peek()
        {
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

        public void Push(T newTop)
        {
            if (!IsFull())
            {
                top = linkSize;
                //Insert(top, newTop); // push one element
                Add(newTop);
                stackSize++;   // increase the size of stack
            }
        }

        public T Pop()
        {
            if (!IsEmpty())
            {
                top = linkSize;
                TValue = Remove(top - 1);  // save value from the top and pass it out from the method 
                                           //arrayA[top - 1] = -1; // delete value 
                top--; // move top one step back
                stackSize--;  // decrease the size of the stack
                return TValue;
            }
            else
            {
                //Console.WriteLine("The stack is empty!");
                return TValue;
            }
        }
    }
}
