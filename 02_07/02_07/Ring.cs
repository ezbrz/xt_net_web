using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_07
{
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
                if (value <= 0 || value > _radius) throw new ArgumentException("Invalid value", "InnerRadius");
                _innerRadius = value;
                _innerLength = 2 * Math.PI * value;
                _area = Math.PI * Math.Pow(_radius, 2) - Math.PI * Math.Pow(value, 2);
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
