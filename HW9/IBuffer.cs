using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    interface IBuffer
    {
        bool IsFull();
        bool IsEmpty();
        void Peek();
        void Print();
    }
}
