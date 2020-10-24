using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;
using GeoСoordination;

namespace OSMCoordination
{
    public class OSMCoordination : IGeoСoordination
    {

        public double[] GetPointsAsync(string place, int count = 1)
        {
            place = HttpUtility.UrlEncode(place);
            string url = string.Concat(" https://nominatim.openstreetmap.org/search.php?q=", place, "&polygon_geojson=1&format=jsonv2");
            var headers = new Dictionary<string, string>();
            headers.Add("User-Agent", "PostmanRuntime/7.26.5");
            var res = Http.GetAsync(url, headers).Result;
            string x = res.Content.ReadAsStringAsync().Result;
            return null;
        }
    }
}
