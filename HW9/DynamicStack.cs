using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    public class DynamicStack<T> : DynamicAbstrBuffer<T>
    {
        private int top;
        private int inx;
        private int realSize;
        private int capacitySize;
        private T TValue;
        private Node head;

        public DynamicStack()
        {
            sizeA = 0;
            count = 0;
            top = 0;
            head = null;
        }

        public DynamicStack(int NewSize)
        {
            sizeA = NewSize;
            count = 0;
            top = 0;
            head = null;
        }

        private class Node
        {
            private Node next;
            private T data;

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
            Node newNode = new Node(newValue);
            newNode.setNextNode(head);// head
            head = newNode;
            count++; //real size
        }

        public override int Capacity()
        {
            return count;
        }

        public override T Get()
        {
            throw new NotImplementedException();
        }

        public override void Insert(int newIndex)
        {
            throw new NotImplementedException();
        }

        public override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public override bool IsFull()
        {
            throw new NotImplementedException();
        }

        public override void Peek()
        {
            throw new NotImplementedException();
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }

        public override void Remove(T oldValue)
        {
            throw new NotImplementedException();
        }

        public override int Size()
        {
            return count;
        }
    }
}
