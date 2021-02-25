using System;
using System.Collections.Generic;
using System.Linq;
using GoogleHashCode.Base;

namespace GoogleHashCode.Model
{
	public record StreetSchedule(string StreetName, int DurationGreem);

	public record Intersection(int ID, List<StreetSchedule> StreetsSchedule);

	public record Output(List<Intersection> Intersections) : IOutput
	{
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