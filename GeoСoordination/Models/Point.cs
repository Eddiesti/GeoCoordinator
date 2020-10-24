using System;
using System.Collections.Generic;
using System.Text;

namespace GeoСoordination.Models
{
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public override string ToString()
        {
            return String.Format("x:{0}, y:{1}", x, y);
        }
    }

    public class Result
    {
        public string Place { get; set; }

        public List<Point> points { get; set; }
    }
}
