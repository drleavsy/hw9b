using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    interface IDynamicArray<T> : IBuffer
    {
        void Add(T newValue);
        void Insert(int newIndex);
        T Get();
        void Remove(T oldValue);
        int Capacity(); // size of the underlying storage
        int Size();// real count of elements
    }
}
