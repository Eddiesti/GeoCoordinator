using GeoСoordination.Models;
using System.Collections.Generic;


namespace GeoСoordination
{
    public class Converter
    {
        public IConverter converter;

        public Converter(IConverter converter)
        {
            this.converter = converter;
        }

        public IEnumerable<Point> Convert(Geo geojson)
        {
            return converter.Convert(geojson);
        }

    }
}
