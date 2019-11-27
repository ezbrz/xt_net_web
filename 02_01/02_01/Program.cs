using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Round NewRound = new Round(new Point(15, 11), 8);
            Console.WriteLine($"Round with center point X = {NewRound.CenterPoint.X}, Y = {NewRound.CenterPoint.Y}. Round area = {NewRound.RoundArea}. Circumference = {NewRound.RoundLength}. Radius = {NewRound.RoundRadius}");
            NewRound.RoundRadius=3;
            NewRound.CenterPoint = new Point(7,4);
            Console.WriteLine($"Round with center point X = {NewRound.CenterPoint.X}, Y = {NewRound.CenterPoint.Y}. Round area = {NewRound.RoundArea}. Circumference = {NewRound.RoundLength}. Radius = {NewRound.RoundRadius}");
            Console.ReadKey();
        }
    }

    class Round
    {
        private double _roundRadius;
        private Point _centerPoint;
        private double _XDistance
        {
            set { if (value < 0) throw new ArgumentException("Round not in positive coordinates, Change X center point or radius"); }
        }
        private double _YDistance
        {
            set { if (value < 0) throw new ArgumentException("Round not in positive coordinates, Change Y center point or radius"); }
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
            _XDistance = point.X - radius;
            _YDistance = point.Y - radius;
        }
        public Round(Point centerPoint, double roundRadius)
        {
            GetDistance(centerPoint, roundRadius);
            CenterPoint = centerPoint;
            RoundRadius = roundRadius;
        }

    }
    class Point
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
