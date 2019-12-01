using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_08
{
    interface IMove
    {
        void Run();
        void Walk();
    }
    interface IFight
    {
        void Attack();
        void Defence();
    }
    interface ICollect
    {
        void Collect();
    }
}
