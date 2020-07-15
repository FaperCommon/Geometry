using System;

namespace Geometry
{

    public class Line
    {
        public Vector V1 { get; }

        private float a, b, c;      //equation
        private const float ex = 0.0001f;

        public Line(Point p1, Point p2)
        {
            V1 = new Vector(p1, p2);

            a = p2.Y - p1.Y;
            b = p1.X - p2.X;
            c = -((p2.X - p1.X) * p1.Y - (p2.Y - p1.Y) * p1.X);

        }

        static public Point IntersectionPointOfVectors(Line l1,Line l2)
        {
            if (!IsParallelLines(l1, l2))
            {   
                Point res = IntersectionPointOfLines(l1, l2);

                float DistanceFromCenter1 = (Vector.GetLength(Vector.GetVector(l1.V1.Center, res)));
                float DistanceFromCenter2 = (Vector.GetLength(Vector.GetVector(l2.V1.Center, res)));

                if ( DistanceFromCenter1 < l1.V1.Length/2)
                {
                    if (DistanceFromCenter2 < l2.V1.Length / 2)
                    {
                        return res;
                    }
                }
            }

            return default(Point);
        }

        static public StateOfLines IsIntersectingState(Line l1,Line l2)
        {
            if (!IsParallelLines(l1, l2))
            {
                return StateOfLines.Intersect;
            }
            else if (PointBelongsToVector(l1,l2.V1.Center))   
            {
                    return StateOfLines.Coincident;
            }

            return StateOfLines.Parallel; ;
        }



        static public bool PointBelongsToVector(Line line, Point p)
        {
            return Math.Abs(line.a * p.X + line.b * p.Y + line.c) < ex;
        }

        static public Point IntersectionPointOfLines(Line l1, Line l2)
        {
            if (IsParallelLines(l1, l2))
                return default(Point);


            float d = Det(l1.a, l1.b, l2.a, l2.b);
            float d1 = Det(l1.c, l1.b, l2.c, l2.b);
            float d2 = Det(l1.a, l1.c, l2.a, l2.c);

            return new Point(d1 / d, d2 / d);
        }


        static public bool IsParallelLines(Line line1, Line line2)
        {
            float k1 = (line1.V1.P2.X - line1.V1.P1.X) / (line1.V1.P2.Y - line1.V1.P1.Y);
            float k2 = (line2.V1.P2.X - line2.V1.P1.X) / (line2.V1.P2.Y - line2.V1.P1.Y);
            return Math.Abs(k1 - k2) < ex;
        }

        static float Det(float a1, float a2, float b1, float b2)
        {
            return a1 * b2 - a2 * b1;
        }



        public static bool operator ==(Line a, Line b)
            => a.V1.P2 == b.V1.P2 && a.V1.P1 == b.V1.P1;

        public static bool operator !=(Line a, Line b)
            => a.V1.P2 != b.V1.P2 && a.V1.P1 != b.V1.P1;

        public override string ToString()
        {
            return String.Format("V1 = {0}", V1.ToString());
        }

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


            //For Coincident Lines
            //else                                      
            //{
            //    if (IsIntersectingState(l1, l2) == StateOfLines.Coincident) {
            //        float DistanceFromCenter =  Vector.GetLength(Vector.GetVector(l1.V1.Center, l2.V1.Center));
            //        float TotalDistacne = Vector.GetLength(Vector.GetVector(l1.V1.Center, l1.V1.P1)) + 
            //            Vector.GetLength(Vector.GetVector(l2.V1.Center, l2.V1.P1));

            //        if ( (DistanceFromCenter - TotalDistacne) > 0)
            //        {
            //            return Vector.GetCenter(l1.V1.Center, l2.V1.Center);
            //        }
            //    }
            //}
