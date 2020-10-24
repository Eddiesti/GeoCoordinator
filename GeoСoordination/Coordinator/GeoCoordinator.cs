using GeoСoordination.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoСoordination
{
    public class GeoCoordinator
    {
        public IGeoCoordinator Coordinator { get; set; }
        public СoordinationType Type { get; set; }
        public GeoCoordinator(IGeoCoordinator Coordinator, СoordinationType Type)
        {
            this.Coordinator = Coordinator;
            this.Type = Type;
        }

        public  IEnumerable<Result> GetPoints(string place, int count = 1)
        {
            return Coordinator.GetPoints(place, count);
        }
    }
}
