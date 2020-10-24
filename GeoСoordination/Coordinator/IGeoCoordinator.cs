using GeoСoordination.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeoСoordination
{
    public interface IGeoCoordinator
    {
        IEnumerable<Result> GetPoints(string place, int count = 1);
    }
}
