using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9B
{
    interface IMyStack<T> : IBuffer<T>
    {
        void Push(T newTop);
        T Pop();
    }
}
