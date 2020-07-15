using System;

namespace Geometry
{

    public class Vector
    {
        public Point P1 { get; }
        public Point P2 { get; }

        public float Length { get; }
        public Point Value { get; }
        public Point Center { get; }

        public Vector(Point p1, Point p2) { P1 = p1; P2 = p2; Value = GetVector(P1, P2); Length = GetLength(Value); Center = GetCenter(p1, p2); }
        public override string ToString()
        {
            return String.Format("P2 = {0}, P1 = {1}", P1.ToString(), P2.ToString());
        }

        public static bool operator ==(Vector a, Vector b)
           => a.P2 == b.P2 && a.P1 == b.P1;

        public static bool operator !=(Vector a, Vector b)
            => a.P2 != b.P2 && a.P1 != b.P1;


        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj.ToString());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        static public float GetLength(Point vector)
        {
            return (float)Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }


        static public Point GetVector(Point point1, Point point2)
        {
            Point vect = new Point
            {
                X = point1.X - point2.X,
                Y = point1.Y - point2.Y
            };
            return vect;
        }
        static public Point GetCenter(Point point1, Point point2)
        {
            Point res = new Point
            {
                X = (point1.X + point2.X) / 2,
                Y = (point1.Y + point2.Y) / 2
            };
            return res;
        }
    }

}
