using System;

namespace Geometry
{
    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Point(float x, float y) { X = x; Y = y; }
        public Point() : this(0, 0) { }
        public override string ToString()
        {
            return String.Format("X = {0}, Y = {1}", X.ToString() , Y.ToString());
        }

        public static bool operator ==(Point a, Point b)
     => a.X == b.Y && a.X == b.Y;

        public static bool operator !=(Point a, Point b)
            => a.X != b.Y && a.X != b.Y;


        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj.ToString());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }

}
