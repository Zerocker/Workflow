using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self
{
    interface IVector
    {
        float GetLength();
        void Multiply(float value);
        string ToString();
    }
}
