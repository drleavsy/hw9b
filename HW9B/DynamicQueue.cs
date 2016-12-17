using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9B
{
    public class DynamicQueue<T> : DynamicAbstrBuffer<T>, IMyQueue<T>
    {
        private int head;
        private int tail;

        private int QSize;
        private int maxSize;
        private int linkSize;
        private T TValue;
        private Node nodeHead;// = new Node();

        public DynamicQueue(int sizeQ)
        {
            head = sizeQ;
            tail = 0;
            QSize = 0;
            maxSize = sizeQ;
            linkSize = 0;
        }

        private class Node
        {
            private Node next;
            private T data;

            public Node()
            {
                next = null;
            }

            public Node(T newData)
            {
                next = null;
                data = newData;
            }
            public T getData()
            {
                return data;
            }
            public void setData(T setData)
            {
                data = setData;
            }
            public Node getNextNode()
            {
                return next;
            }
            public void setNextNode(Node setNode)
            {
                next = setNode;
            }
        }

        public override void Add(T newValue)
        {
            if (nodeHead == null)
            {
                nodeHead = new Node(newValue);
                linkSize++;
            }
            else
            {
                Node newNode = new Node(newValue);

                Node CurrentCursor = nodeHead;
                while (CurrentCursor.getNextNode() != null)
                {
                    CurrentCursor = CurrentCursor.getNextNode();
                }

                CurrentCursor.setNextNode(newNode);// head
                linkSize++;
            }
        }

        public override T Get(int ind)
        {
            int counter = 0;
            Node current = nodeHead;
            if (current.getNextNode() == null)
            {
                return current.getData();
            }
            else
            {
                while (counter < ind && current.getNextNode() != null)
                {
                    current = current.getNextNode();
                    counter++;
                }
                return current.getData();
            }
        }

        public override void Insert(int ind, T newVal)
        {
            int counter = 0;

            Node PrevNode = null;
            Node NextNode = null;
            Node IndxNode = null;
            if (ind <= linkSize && ind >= 0)
            {
                if (nodeHead == null)
                {
                    nodeHead = new Node(newVal);
                    linkSize++;
                }
                else
                {
                    Node newNode = new Node(newVal);
                    Node CurrentCursor = nodeHead;
                    if (ind == 0)
                    {
                        newNode.setNextNode(nodeHead);
                        nodeHead = newNode;
                        linkSize++;
                        return;
                    }
                    while (counter < ind - 1 && CurrentCursor.getNextNode() != null)
                    {
                        CurrentCursor = CurrentCursor.getNextNode();
                        counter++;
                    }

                    PrevNode = CurrentCursor;

                    if (PrevNode.getNextNode() != null)
                    {
                        while (counter < ind && CurrentCursor.getNextNode() != null)
                        {
                            CurrentCursor = CurrentCursor.getNextNode();
                            counter++;
                        }
                        IndxNode = CurrentCursor;
                        if (IndxNode.getNextNode() != null)
                        {
                            while (counter < ind + 1 && CurrentCursor.getNextNode() != null)
                            {
                                CurrentCursor = CurrentCursor.getNextNode();
                                counter++;
                            }
                            NextNode = CurrentCursor;

                            PrevNode.setNextNode(newNode);
                            newNode.setNextNode(IndxNode);
                            IndxNode.setNextNode(NextNode);
                            linkSize++;
                        }
                        else
                        {
                            PrevNode.setNextNode(newNode);
                            newNode.setNextNode(IndxNode);
                            linkSize++;
                        }
                    }
                    else
                    {
                        PrevNode.setNextNode(newNode);
                        newNode.setNextNode(null);
                        linkSize++;
                    }
                }
            }
        }

        public override T Remove(int ind)
        {
            int counter = 0;

            Node PrevNode = null;
            Node NextNode = null;
            Node IndxNode = null;
            if (linkSize > 0 && ind < linkSize && ind >= 0)
            {
                Node CurrentCursor = nodeHead;
                if (ind == 0)
                {
                    nodeHead = CurrentCursor.getNextNode();
                    CurrentCursor.setNextNode(null);
                    linkSize--;
                    return CurrentCursor.getData();
                }
                while (counter < ind - 1 && CurrentCursor.getNextNode() != null)
                {
                    CurrentCursor = CurrentCursor.getNextNode();
                    counter++;
                }

                PrevNode = CurrentCursor;

                if (PrevNode.getNextNode() != null)
                {
                    while (counter < ind && CurrentCursor.getNextNode() != null)
                    {
                        CurrentCursor = CurrentCursor.getNextNode();
                        counter++;
                    }
                    IndxNode = CurrentCursor;
                    if (IndxNode.getNextNode() != null)
                    {
                        while (counter < ind + 1 && CurrentCursor.getNextNode() != null)
                        {
                            CurrentCursor = CurrentCursor.getNextNode();
                            counter++;
                        }
                        NextNode = CurrentCursor;

                        PrevNode.setNextNode(NextNode);
                        IndxNode.setNextNode(null);
                        linkSize--;
                        return IndxNode.getData();
                    }
                    else
                    {
                        PrevNode.setNextNode(null);
                        IndxNode.setNextNode(null);
                        linkSize--;
                        return IndxNode.getData();
                    }
                }
            }
            return TValue;
        }

        public override int Size()
        {
            return linkSize;
        }

        public override bool IsFull()
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

        public override bool IsEmpty()
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

        public override T Peek()
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

        public override void Print()
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
