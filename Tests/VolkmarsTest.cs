using System;
using GoogleHashCode;
using GoogleHashCode.Algorithms;
using GoogleHashCode.Model;
using NUnit.Framework;

namespace Tests
{
	public class VolkmarsTest
	{
		[Test]
		[Parallelizable(ParallelScope.All)]
		[TestCase("a.txt")]
		[TestCase("b.txt")]
		[TestCase("c.txt")]
		[TestCase("d.txt")]
		[TestCase("e.txt")]
		[TestCase("f.txt")]
		public void Solver2(string example)
		{
			var content = example.ReadFromFile();
			var solver = new Solver2();
			var input = Input.Parse(content);
			var output = solver.Solve(input);

			Console.WriteLine($"Total Score: {output.GetScore(input):N0}");
			example.WriteToFile(output.GetOutputFormat());
			Assert.Pass();
		}
	}
}