using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_07
{
    abstract public class Figure
    {
        protected double Area
        { get => _area; }
        protected double Angle
        { get => _angle; set => _angle = value; }
        protected Point CenterCoordinates
        { get => _centerPoint; set => _centerPoint = value; }
        protected double Length
        { get => _length; }
        abstract public void GetInfo();
        private protected double _length;
        private protected double _angle;
        private protected double _area;
        private protected double _radius;
        private protected Point _centerPoint;
        private protected FigureType Type;
    }
    public struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    enum FigureType
    {
        Line,
        Circle,
        Round,
        Ring,
        Square
    }
}
