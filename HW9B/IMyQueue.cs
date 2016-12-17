﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9B
{
    interface IMyQueue<T> : IBuffer<T>
    {
        void Enqueue(T newTop);
        T Dequeue();
    }
}
