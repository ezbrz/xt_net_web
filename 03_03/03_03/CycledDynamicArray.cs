using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_03
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public override bool MoveNext()
        {
            if (_currentPos == Length - 1)
            {
                Reset();
                return true;
            }
            _currentPos++;
            return true;
        }

    }
}
