
using System.Collections.Generic;
using System.Linq;
using GeoСoordination.Models;
using Newtonsoft.Json.Linq;

namespace GeoСoordination
{
    public class MultiPoligonConverter : IConverter
    {
        private int count;

        public MultiPoligonConverter(int count)
        {
            this.count = count;
        }

        public MultiPoligonConverter()
        {
            this.count = 1;
        }

        public IEnumerable<Point> Convert(Geo coordinates)
        {
            var points = new List<Point>();
            var list = ((JArray)coordinates.Coordinates).SelectMany(s => s.Children().First().Select(t => t)).ToList();
            int i = 0;
            for (; i < list.Count;)
            {
                if (i % count == 0)
                {
                    var d = ((JArray)list[i]).ToObject<double[]>();
                    Point point = new Point
                    {
                        x = d[0],
                        y = d[1]
                    };
                    points.Add(point);
                }
                i += count;
            }
            return points;
        }
    }
}
