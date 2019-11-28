using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_06
{
    class RoundFigure
    {
        protected double _radius;
        protected Point _centerPoint;



        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value. Must be > 0", nameof(Radius));
                _radius = value;
            }
        }

        public double RoundLength
        {
            get => 2 * Math.PI * _radius;
        }
        public Point CenterPoint
        {
            get => _centerPoint;
            set
            {
                if (value.X <= 0 || value.Y <= 0) throw new ArgumentException("Invalid coordinates. Must be > 0", nameof(CenterPoint));
                _centerPoint = value;
            }
        }
        public RoundFigure(Point centerPoint, double roundRadius)
        {
            CenterPoint = centerPoint;
            Radius = roundRadius;
        }
        public override string ToString()
        {
            return $"Round figure with center point X = {CenterPoint.X}, Y = {CenterPoint.Y}. Circumference = {RoundLength}. Radius = {Radius}";
        }
    }
    struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
