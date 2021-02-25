using System;
using System.Collections.Generic;
using System.Linq;
using GoogleHashCode.Base;

namespace GoogleHashCode.Model
{
	public record StreetSchedule(string StreetName, int DurationGreen);

	public record Intersection(int ID, List<StreetSchedule> StreetsSchedule);

	public record Output(List<Intersection> Intersections) : IOutput
	{
		public string[] GetOutputFormat()
		{
			var output = new List<string>();
			output.Add(Intersections.Count.ToString());
            foreach (var intersection in Intersections)
            {
				output.Add(intersection.ID.ToString());
				output.Add(intersection.StreetsSchedule.Count.ToString());
                foreach (var streetSchedule in intersection.StreetsSchedule)
					output.Add($"{streetSchedule.StreetName} {streetSchedule.DurationGreen}");
			}

			return output.ToArray();
		}

		public int GetScore(Input input)
		{
			return 0;
		}
	}
}