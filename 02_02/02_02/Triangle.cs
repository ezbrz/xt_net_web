using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_02
{
    class Triangle
    {
        private Side _triangleSides;
        public Side TriangleSides
        {
            get => _triangleSides;
            set
            {
                if (value.A<=0||value.B<=0||value.C<=0) throw new ArgumentException("Invalid value. Must be > 0", nameof(value));
                if (value.A+value.B<=value.C|| value.A + value.C <= value.B|| value.C + value.B <= value.A) throw new ArgumentException("This triangle can't be. One of side bigger than sum of two another", nameof(value));
                _triangleSides = value;
            }
        }
        public double TriangleArea
        {
            get => Math.Sqrt(TrianglePerimetr/2*(TrianglePerimetr/2 -_triangleSides.A) * (TrianglePerimetr/2 - _triangleSides.B) * (TrianglePerimetr/2 - _triangleSides.C));
        }

        public double TrianglePerimetr
        {
            get => _triangleSides.A + _triangleSides.B + _triangleSides.C;
        }

        public Triangle(Side triangleSides)
        {
            TriangleSides = triangleSides;
        }
        public override string ToString()
        {
            return $"Triangle with sides A = {TriangleSides.A}, B = {TriangleSides.B}, C = {TriangleSides.C}. Triangle area = {TriangleArea}. Perimetr = {TrianglePerimetr}";
        }
    }
    struct Side
    {
        public double A;
        public double B;
        public double C;
        public Side(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}
