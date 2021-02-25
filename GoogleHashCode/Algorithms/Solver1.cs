using System;
using System.Collections.Generic;
using System.Linq;
using GoogleHashCode.Base;
using GoogleHashCode.Model;

namespace GoogleHashCode.Algorithms
{
	public class Solver1 : ISolver<Input, Output>
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
				.ToDictionary(c => c.StreetName, c => c.Count);

			var notUsedStreets = input.Streets.Select(r => r.StreetName)
				.Except(allCarPaths.Keys)
				.ToList();
			
			foreach (var inputStreet in intersectionsWithStreets)
			{
				var schedule = new List<StreetSchedule>();

				foreach (var street in inputStreet.Streets.Except(notUsedStreets))
				{
					schedule.Add(new StreetSchedule(street, 1));
				}
				
				if (!schedule.Any())
					schedule.Add(new StreetSchedule(inputStreet.Streets.First(), 1));


				var intersection = new Intersection(inputStreet.Id, schedule);
				intersections.Add(intersection);
			}

			return new Output(intersections);
		}
	}
}