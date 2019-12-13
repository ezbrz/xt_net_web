using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_07
{
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
        public Round(Point cpoint, double radius) : base(cpoint, radius)
        {
            CenterCoordinates = cpoint;
            Radius = radius;
            Type = FigureType.Round;
        }
    }
}
