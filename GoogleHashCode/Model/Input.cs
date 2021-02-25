using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode.Model
{

    public record Street(int BeginIntersectionID, int EndIntersectionID, string StreetName, int Length);

    public record CarPath(int NumberOfStreets, List<string> StreetNames);

    public record Input(int Duration, int NumberOfIntersections, int NumberOfStreets, int NumberOfCars, int BonusPoints, List<Street> Streets, List<CarPath> CarPaths)
    {
        static Street ParseStreet(string line)
        {
            var list = line.Split(" ", System.StringSplitOptions.RemoveEmptyEntries).ToList();
            return new Street(int.Parse(list[0]), int.Parse(list[1]), list[2], int.Parse(list[3]));
        }

        static CarPath ParseCarPath(string line)
        {
            var list = line.Split(" ", System.StringSplitOptions.RemoveEmptyEntries).ToList();
            return new CarPath(int.Parse(list[0]), list.Skip(1).ToList());
        }

        public static Input Parse(string[] values)
        {
            var first = values.First().Split(" ", System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            return new(Duration: first[0], NumberOfIntersections: first[1], NumberOfStreets: first[2], NumberOfCars: first[3], BonusPoints: first[4], Streets: values.Skip(1).Take(first[2]).Select(ParseStreet).ToList(), CarPaths: values.Skip(1 + first[2]).Select(ParseCarPath).ToList());
        }
    }
}