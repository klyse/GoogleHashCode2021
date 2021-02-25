using System;
using System.Collections.Generic;
using System.Linq;
using GoogleHashCode.Base;

namespace GoogleHashCode.Model
{
	public record StreetSchedule
    {
		public string StreetName;
		public int DurationGreem;
	}

	public record Intersection
    {
		public int ID;
		public List<StreetSchedule> StreetsSchedule = new();
    }


	public record Output : IOutput
	{
		public List<Intersection> Intersections = new();

		public string[] GetOutputFormat()
		{
			return null;
		}

		public int GetScore(Input input)
		{
			return 0;
		}
	}
}