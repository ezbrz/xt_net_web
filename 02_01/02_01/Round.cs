using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_01
{
    class Round
    {
        private double _roundRadius;
        private Point _centerPoint;
        private double XDistance
        {
            set { if (value < 0) throw new ArgumentException("Round not in I quater of coordinate plane, Change X center point or radius"); }
        }
        private double YDistance
        {
            set { if (value < 0) throw new ArgumentException("Round not in I quater of coordinate plane, Change Y center point or radius"); }
        }


        public double RoundRadius
        {
            get => _roundRadius;
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value. Must be > 0", nameof(RoundRadius));
                GetDistance(_centerPoint, value);
                _roundRadius = value;
            }
        }
        public double RoundArea
        {
            get => Math.PI * Math.Pow(_roundRadius, 2);
        }

        public double RoundLength
        {
            get => 2 * Math.PI * _roundRadius;
        }
        public Point CenterPoint
        {
            get => _centerPoint;
            set
            {
                if (value.X <= 0 || value.Y <= 0) throw new ArgumentException("Invalid coordinates. Must be > 0", nameof(CenterPoint));
                GetDistance(value, _roundRadius);
                _centerPoint = value;
            }
        }
        private void GetDistance(Point point, double radius)
        {
            XDistance = point.X - radius;
            YDistance = point.Y - radius;
        }
        public Round(Point centerPoint, double roundRadius)
        {
            CenterPoint = centerPoint;
            RoundRadius = roundRadius;
            GetDistance(centerPoint, roundRadius);
        }
        public override string ToString()
        {
            return $"Round with center point X = {CenterPoint.X}, Y = {CenterPoint.Y}. Round area = {RoundArea}. Circumference = {RoundLength}. Radius = {RoundRadius}";
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
