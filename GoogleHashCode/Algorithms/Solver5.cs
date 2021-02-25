using System;
using System.Collections.Generic;
using System.Linq;
using GoogleHashCode.Base;
using GoogleHashCode.Model;

namespace GoogleHashCode.Algorithms
{
	public class Solver5 : ISolver<Input, Output>
	{
		public Output Solve(Input input)
		{
			var intersections = new List<Intersection>();

			var intersectionsWithStreets = input.Streets
				.GroupBy(c => new
				{
					Id = c.EndIntersectionID
				})
				.Select(c => new
				{
					c.Key.Id,
					Streets = c.Select(r => r.StreetName)
				});

			var allCarPaths = input.CarPaths.SelectMany(c => c.StreetNames)
				.GroupBy(c => c)
				.Select(c => new
				{
					StreetName = c.Key,
					Count = c.Count()
				})
				.ToList();

			var allCarPathsDict = allCarPaths.ToDictionary(c => c.StreetName, c => c.Count);

			var highValueStreets = allCarPaths
				.OrderByDescending(c => c.Count)
				.Take(allCarPaths.Count / 20)
				.Select(c => c.StreetName)
				.ToHashSet();

			var lowValueStreets = allCarPaths
				.OrderBy(c => c.Count)
				.Take(allCarPaths.Count / 20)
				.Select(c => c.StreetName)
				.ToHashSet();

			var notUsedStreets = input.Streets.Select(r => r.StreetName)
				.Except(allCarPaths.Select(r => r.StreetName))
				.ToList();

			foreach (var intersectionWithStreets in intersectionsWithStreets)
			{
				var schedule = new List<StreetSchedule>();

				var validStreets = intersectionWithStreets.Streets
					.Except(notUsedStreets)
					.ToList();

				double totalCrossings = validStreets.Sum(c => allCarPathsDict[c]);

				var maxTotalTime = Math.Min(60, validStreets.Count);

				var streetValue = new Dictionary<string, double>();

				if (!validStreets.Any())
				{
					foreach (var street in intersectionWithStreets.Streets)
					{
						schedule.Add(new StreetSchedule(street, 1));
					}

					continue;
				}

				foreach (var street in validStreets)
				{
					double value = allCarPathsDict[street] / totalCrossings * 100;

					// if (highValueStreets.Contains(street))
					// 	value *= 2;
					//
					// if (lowValueStreets.Contains(street))
					// 	value /= 2;

					streetValue[street] = value;
				}

				var maxPerCrossing = 10;
				double sumVal = streetValue.Sum(c => c.Value);

				foreach (var street in validStreets)
				{
					double value = streetValue[street] / sumVal * maxPerCrossing;

					value = Math.Min(value, maxPerCrossing);
					value = Math.Max(value, 1);

					schedule.Add(new StreetSchedule(street, (int) value));
				}


				var intersection = new Intersection(intersectionWithStreets.Id, schedule);
				intersections.Add(intersection);
			}

			return new Output(intersections);
		}
	}
}