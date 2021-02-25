using GoogleHashCode.Base;
using GoogleHashCode.Model;
using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode.Algorithms
{

    public class Solver2 : ISolver<Input, Output>
    {
        public Output Solve(Input input)
        {
            var startStreets = input.CarPaths.Select(q => q.StreetNames.First()).GroupBy(q => q).Select(q => new { streetName = q.Key, count = q.Count() }).OrderByDescending(q => q.count).ToList();


            var intersections = new Dictionary<int, Intersection>();
            Intersection GetIntersection(int id)
            {
                if (!intersections.TryGetValue(id, out var result))
                {
                    result = new Intersection(id, new List<StreetSchedule>());
                    intersections.Add(id, result);
                }
                return result;
            }




            // Starter
            foreach (var item in startStreets)
            {
                var id = input.Streets.First(q => q.StreetName == item.streetName).EndIntersectionID;
                GetIntersection(id).StreetsSchedule.Add(new StreetSchedule(item.streetName, item.count));
            }

            // rest

            var allCarPaths = input.CarPaths.SelectMany(c => c.StreetNames.Skip(1)).Distinct().ToHashSet();
            var usedStreets = input.Streets.Where(q => allCarPaths.Contains(q.StreetName)).ToList();

            foreach (var item in input.Streets)
            {
                var inter = GetIntersection(item.EndIntersectionID);
                if (!inter.StreetsSchedule.Any(q => q.StreetName == item.StreetName))
                    inter.StreetsSchedule.Add(new StreetSchedule(item.StreetName, 1));
            }

            return new Output(intersections.Values.ToList());
        }
    }
}