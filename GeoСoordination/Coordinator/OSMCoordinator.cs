using System.Collections.Generic;
using System.Linq;
using GeoСoordination.Models;
using Newtonsoft.Json;


namespace GeoСoordination
{
    public class OSMCoordinator : IGeoCoordinator
    {
        /// <summary>
        /// Получаем точки с помощью апи OSM
        /// </summary>
        /// <param name="place">Адреса для поиска полигона через ;</param>
        /// <param name="count">Частота точек</param>
        /// <returns></returns>
        public IEnumerable<Result> GetPoints(string places, int count = 1)
        {
            var result = new List<Result>();
            foreach (var place in places.Split(";"))
            {
                var points = new List<Point>();
                var url = string.Concat(" https://nominatim.openstreetmap.org/search.php?q=", place, "&polygon_geojson=1&format=jsonv2");

                var headers = new Dictionary<string, string>
                {
                    { "User-Agent", "PostmanRuntime/7.26.5" }
                };

                var json = Http.GetAsync(url, headers).Result.Content.ReadAsStringAsync().Result;

                var myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(json);

                foreach (var f in myDeserializedClass)
                {
                    switch (f.Geojson.Type)
                    {
                        case "MultiPolygon":
                            points.AddRange(new Converter(new MultiPoligonConverter(count)).Convert(f.Geojson));
                            continue;
                        case "Polygon":
                            var rx = new Converter(new PoligonConverter(count)).Convert(f.Geojson);
                            points.AddRange(rx);
                            continue;
                        case "Point":
                            points.AddRange(new Converter(new PointConverter()).Convert(f.Geojson));
                            continue;
                    }
                }
                var r = new Result
                {
                    Place = place,
                    points = points
                };
                result.Add(r);
            }
            return result;
        }
    }

}
