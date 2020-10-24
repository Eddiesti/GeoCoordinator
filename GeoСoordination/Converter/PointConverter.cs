using System;
using System.Collections.Generic;
using System.Text;
using GeoСoordination.Models;
using Newtonsoft.Json.Linq;

namespace GeoСoordination
{
    public class PointConverter : IConverter
    {
        public IEnumerable<Point> Convert(Geo coordinates)
        {
            var points = new List<Point>();
            var d = ((JArray)coordinates.Coordinates).ToObject<double[]>();
            Point point = new Point
            {
                x = d[0],
                y = d[1]
            };
            points.Add(point);
            return points;
        }
    }
}
