using GeoСoordination.Models;
using System.Collections.Generic;

namespace GeoСoordination
{
    public interface IConverter
    {
        IEnumerable<Point> Convert(Geo coordinates);
    }
}
