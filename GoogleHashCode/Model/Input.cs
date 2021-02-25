using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode.Model
{

    public record Street(int Begin, int End, string StreetName, int Length);

    public record CarPath(int NumberOfStreets, List<string> StreetNames);

    public record Input(int Duration, int NumberOfIntersections, int NumberOfStreets, int NumberOfCars, int BonusPoints, List<Street> Streets, List<CarPath> CarPaths)
    { 
        public static Input Parse(string[] values)
        {
            var first = values.First().Split(" ", System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();


            //return new()
            //{
            //    Duration = first[0],

            //    Duration = first[0];
            //NumberOfIntersections = first[1];
            //NumberOfStreets = first[2];
            //NumberOfCars = first[3];
            //BonusPoints = first[4];

            return null;
        }
    }
}