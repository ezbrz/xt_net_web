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

    public class Line : Figure
    {
        public new double Length
        {
            get => _length;
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value", "Length");
                _length = value;
            }
        }
        public override void GetInfo()
        {
            Console.WriteLine($"This is {Type} with center coordinates X = {CenterCoordinates.X}, Y = {CenterCoordinates.Y}. Length = {Length}.\n{Type} has no area (Area = {Area}), {Type} tilt angle = {Angle}\u00B0\n");
        }
        public Line(Point cpoint, double length, double angle)
        {
            CenterCoordinates = cpoint;
            Length = length;
            Angle = angle;
            _area = 0;
            Type = FigureType.Line;
        }
    }
    public class Square : Figure
    {
        private double _side;
        public double Side
        {
            get => _side;
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value", "Side");
                _area = Math.Pow(value,2);
                _side = value;
                _length = 4 * value;
            }
        }
        public override void GetInfo()
        {
            Console.WriteLine($"This is {Type} with center coordinates X = {CenterCoordinates.X}, Y = {CenterCoordinates.Y}. Side = {Side}. {Type} area = {Area}, Perimetr = {Length}.\n{Type} tilt angle = {Angle}\u00B0");
        }
        public Square(Point cpoint, double side, double angle)
        {
            Type = FigureType.Square;
            CenterCoordinates = cpoint;
            Side = side;
            Angle = angle;
        }
    }
    public class Circle : Figure
    {
        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value", "Radius");
                _length = 2 * Math.PI * value;
                _radius = value;
            }
        }
        public override void GetInfo()
        {
            Console.WriteLine($"This is {Type} with center coordinates X = {CenterCoordinates.X}, Y = {CenterCoordinates.Y}. Radius = {Radius}. Circumference = {Length}.\n{Type} has no area (Area = {Area}), {Type} has no tilt angle(Tilt angle = {Angle}\u00B0)\n");
        }
        public Circle(Point cpoint, double radius)
        {
            CenterCoordinates = cpoint;
            Radius = radius;
            Angle = 0;
            _area = 0;
            Type = FigureType.Circle;
        }
    }

    public class Round : Circle
    {
        public new double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value", "Radius");
                _length = 2 * Math.PI * value;
                _area = Math.PI * Math.Pow(value, 2);
                _radius = value;
            }
        }
        public override void GetInfo()
        {
            Console.WriteLine($"This is {Type} with center coordinates X = {CenterCoordinates.X}, Y = {CenterCoordinates.Y}. Radius = {Radius}. Circumference = {Length}.\nArea = {Area}, {Type} has no tilt angle(Tilt angle = {Angle}\u00B0)\n");
        }
        public Round(Point cpoint, double radius): base(cpoint, radius)
        {
            CenterCoordinates = cpoint;
            Radius = radius;
            Type = FigureType.Round;
        }
    }

    public class Ring : Round
    {
        private double _innerRadius;
        private double _innerLength;
        public double InnerLength { get => _innerLength; }
        public double InnerRadius
        {
            get => _innerRadius;
            set
            {
                if (value <= 0||value>_radius) throw new ArgumentException("Invalid value", "InnerRadius");
                _innerRadius = value;
                _innerLength = 2 * Math.PI * value;
                _area = Math.PI * Math.Pow(_radius, 2) -Math.PI * Math.Pow(value, 2);
            }
        }

        public new double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value", "Radius");
                _length = 2 * Math.PI * value;
                _radius = value;
            }
        }
        public override void GetInfo()
        {
            Console.WriteLine($"This is {Type} with center coordinates X = {CenterCoordinates.X}, Y = {CenterCoordinates.Y}. Outer radius = {Radius}. Inner radius = {InnerRadius}.\nOuter circumference = {Length}. Inner circumference = {InnerLength}.\nArea = {Area}, {Type} has no tilt angle(Tilt angle = {Angle}\u00B0)\n");
        }
        public Ring(Point cpoint, double radius, double innerradius) : base(cpoint, radius)
        {
            CenterCoordinates = cpoint;
            Radius = radius;
            InnerRadius = innerradius;
            Type = FigureType.Ring;
        }
    }
}
