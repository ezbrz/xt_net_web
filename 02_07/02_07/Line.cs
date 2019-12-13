using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_07
{
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
}
