using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_2
{
    class Program
    {

        public struct Point
        {
            public float x;
            public float y;
            public Point(float xx, float yy)
            {
                x = xx;
                y = yy;
            }
        }


        public struct rect
        {

            public Point left;
            public Point right;

            public rect(Point l, Point r)
            {
                left = l;
                right = r;
            }

            public bool TryParsePoint(string point, out float start, out float end)
            {
                string border_before = "({[";
                string border_after = ")}]";
                bool allcorrect = false;
                if (border_before.Contains(point[0]) && border_after.Contains(point[point.Length - 1]))
                {
                    string[] items = point.Substring(1, point.Length - 1).Split(',');
                    if (items.Length == 2)
                    {
                        allcorrect = float.TryParse(items[0], out start) & float.TryParse(items[1], out end);
                    }
                }
                start = 0;
                end = 0;
                return allcorrect;
            }

            public bool TryParseStringToRect(string source)
            {
                string[] points = source.Split(',');
                left = new Point(0, 0);
                right = new Point(0, 0);
                if (points.Length == 2)
                {
                    return TryParsePoint(points[0], out left.x, out left.y) & TryParsePoint(points[0], out right.x, out right.y);
                }
                
                return false;
            }
        }

        public static rect findInnerRect(List<rect> rects)
        {

            List<float> Xs = new List<float>();
            List<float> Ys = new List<float>();

            foreach (rect r in rects)
            {
                Xs.Add(r.left.x);
                Xs.Add(r.right.x);
                Ys.Add(r.left.y);
                Ys.Add(r.right.y);
            }

            Point Left = new Point(0,0);
            Point Right = new Point(0, 0);

            Left.y = Ys.Min();
            Left.x = Xs.Max();

            Right.y = Ys.Max();
            Right.x = Xs.Min();

            return new rect(Left, Right);
        }

        public static rect findOuterRect(List<rect> rects)
        {

            List<float> Xs = new List<float>();
            List<float> Ys = new List<float>();

            foreach (rect r in rects)
            {
                Xs.Add(r.left.x);
                Xs.Add(r.right.x);
                Ys.Add(r.left.y);
                Ys.Add(r.right.y);
            }

            Point Left = new Point(0, 0);
            Point Right = new Point(0, 0);

            Left.y = Ys.Max();
            Left.x = Xs.Min();

            Right.y = Ys.Min();
            Right.x = Xs.Max();

            return new rect(Left, Right);
        }

        static void Main(string[] args)
        {
        }
    }
}
