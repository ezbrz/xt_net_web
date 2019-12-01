using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_08
{
    abstract class Player: IMove, ICollect, IFight
    {
        protected double Speed;
        protected double HealthPOint;
        protected double AttackPower;
        protected double BlockPower;
        protected PlayerType _type;
        public abstract void Attack();
        public abstract void Defence();
        public abstract void Walk();
        public abstract void Run();
        public abstract void Collect();
    }
    public enum PlayerType
    {
        Elf,
        Orc,
        Human,
    }
}
