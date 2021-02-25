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
		[TestCase("a.txt")]
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

		[Test]
		[TestCase("b.txt")]
		public void Solver3(string example)
		{
			var content = example.ReadFromFile();
			var solver = new Solver3();
			var input = Input.Parse(content);
			var output = solver.Solve(input);

			Console.WriteLine($"Total Score: {output.GetScore(input):N0}");
			example.WriteToFile(output.GetOutputFormat());
			Assert.Pass();
		}

		[Test]
		[TestCase("c.txt")]
		public void Solver4(string example)
		{
			var content = example.ReadFromFile();
			var solver = new Solver4();
			var input = Input.Parse(content);
			var output = solver.Solve(input);

			Console.WriteLine($"Total Score: {output.GetScore(input):N0}");
			example.WriteToFile(output.GetOutputFormat());
			Assert.Pass();
		}

		[Test]
		[Parallelizable(ParallelScope.All)]
		[TestCase("d.txt")]
		public void Solver5(string example)
		{
			var content = example.ReadFromFile();
			var solver = new Solver5();
			var input = Input.Parse(content);
			var output = solver.Solve(input);

			Console.WriteLine($"Total Score: {output.GetScore(input):N0}");
			example.WriteToFile(output.GetOutputFormat());
			Assert.Pass();
		}

		[Test]
		[TestCase("e.txt")]
		public void Solver6(string example)
		{
			var content = example.ReadFromFile();
			var solver = new Solver6();
			var input = Input.Parse(content);
			var output = solver.Solve(input);

			Console.WriteLine($"Total Score: {output.GetScore(input):N0}");
			example.WriteToFile(output.GetOutputFormat());
			Assert.Pass();
		}

		[Test]
		[TestCase("f.txt")]
		public void Solver7(string example)
		{
			var content = example.ReadFromFile();
			var solver = new Solver7();
			var input = Input.Parse(content);
			var output = solver.Solve(input);

			Console.WriteLine($"Total Score: {output.GetScore(input):N0}");
			example.WriteToFile(output.GetOutputFormat());
			Assert.Pass();
		}
	}
}