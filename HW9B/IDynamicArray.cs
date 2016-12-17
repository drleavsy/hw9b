using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9B
{
    interface IDynamicArray<T> 
    {
        void Add(T newValue);
        void Insert(int newIndex,T newVal);
        T Remove(int ind);
        T Get(int ind);
        int Size();// real count of elements
    }
}
