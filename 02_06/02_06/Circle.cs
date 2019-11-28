using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_06
{
    class Circle : RoundFigure
    {
        private double _innerRadius;
        public double InnerRadius
        {
            get => _innerRadius;
            set
            {
                if (value <= 0) throw new ArgumentException("Invalid value. Must be > 0", nameof(InnerRadius));
                if (value >= _radius) throw new ArgumentException("Invalid value. Must be < outer radius", nameof(InnerRadius));
                _innerRadius = value;
            }
        }
        public double CircleWidth
        {
            get => _radius-_innerRadius;
        }
        public double CircleArea
        {
            get => Math.PI * Math.Pow(_radius, 2)- Math.PI * Math.Pow(_innerRadius, 2);
        }
        public Circle(Point centerPoint, double outerRadius, double innerRadius): base(centerPoint, outerRadius)
        {
            CenterPoint = centerPoint;
            Radius = outerRadius;
            InnerRadius = innerRadius;
        }
        public override string ToString()
        {
            return $"Circle with center point X = {CenterPoint.X}, Y = {CenterPoint.Y}. Circle width = {CircleWidth}. Area = {CircleArea}";
        }
    }
}
