using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_08
{
    abstract class Monsters :IFight, IMove
    {
        protected double Speed;
        protected double HealthPOint;
        protected double AttackPower;
        protected double BlockPower;
        public abstract void Attack();
        public abstract void Defence();
        public abstract void Walk();
        public abstract void Run();
    }

    class Wolf : Monsters
    {
        public override void Attack()
        {
        }
        public override void Defence()
        {
        }
        public override void Walk()
        {
        }
        public override void Run()
        {
        }
    }
    class Bear : Monsters
    {
        public override void Attack()
        {
        }
        public override void Defence()
        {
        }
        public override void Walk()
        {
        }
        public override void Run()
        {
        }
    }
}
