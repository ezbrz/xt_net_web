using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_07
{
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
}
