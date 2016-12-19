using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9B
{
    public abstract class DynamicAbstrBuffer<T> : IDynamicArray<T>
    {
        public abstract void Add(T newValue);
        public abstract T Get(int ind);
        public abstract void Insert(int ind, T newVal);
        public abstract T Remove(int ind);
        /*
        public abstract bool IsFull();
        public abstract bool IsEmpty();
        public abstract T Peek();
        public abstract void Print();*/
    }
}
