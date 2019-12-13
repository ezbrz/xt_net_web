using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_07
{
    public class Square : Figure
    {
        private double _side;
        public double Side
        {
            get => _side;
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value", "Side");
                _area = Math.Pow(value, 2);
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
}
