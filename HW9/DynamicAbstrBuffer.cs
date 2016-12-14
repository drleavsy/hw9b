using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    public abstract class DynamicAbstrBuffer<T> : IDynamicArray<T>
    {
        protected int sizeA;
        protected int count; // 
        
        public abstract void Add(T newValue);
        public abstract int Capacity();
        public abstract T Get();
        public abstract void Insert(int newIndex);
        public abstract void Remove(T oldValue);
        public abstract int Size();

        public abstract bool IsFull();
        public abstract bool IsEmpty();
        public abstract void Peek();
        public abstract void Print();
    }
}
