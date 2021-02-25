using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode.Model
{

    public record Street
    {
        public int Begin;
        public int End;
        public string StreetName;
        public int Length;
    }

    public record CarPath
    {
        public int NumberOfStreets;
        public List<string> StreetNames;
    }

    public record Input
	{
        public int Duration;
        public int NumberOfIntersections;
        public int NumberOfStreets;
        public int NumberOfCars;
        public int BonusPoints;

        public List<Street> Streets = new();

        public static Input Parse(string[] values)
		{
			return new();
		}
	}
}