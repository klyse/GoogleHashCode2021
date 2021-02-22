using System;
using System.Collections.Generic;
using System.Linq;
using GoogleHashCode.Base;

namespace GoogleHashCode.Model
{

	public record Output : IOutput
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