using System;
using GoogleHashCode;
using GoogleHashCode.Algorithms;
using GoogleHashCode.Model;
using NUnit.Framework;

namespace Tests
{
	public class KlysesTest
	{
		[Test]
		[Parallelizable(ParallelScope.All)]
		[TestCase("a_example.in")]
		[TestCase("b_little_bit_of_everything.in")]
		[TestCase("c_many_ingredients.in")]
		[TestCase("d_many_pizzas.in")]
		[TestCase("e_many_teams.in")]
		public void Solver1(string example)
		{
			var content = example.ReadFromFile();
			var solver = new Solver1();
			var input = Input.Parse(content);
			var output = solver.Solve(input);

			Console.WriteLine($"Total Score: {output.GetScore(input):N0}");
			example.WriteToFile(output.GetOutputFormat());
			Assert.Pass();
		}
	}
}