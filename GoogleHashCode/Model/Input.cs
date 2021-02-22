using System.Collections.Generic;
using System.Linq;

namespace GoogleHashCode.Model
{
	public record Input
	{
		public static Input Parse(string[] values)
		{
			return new();
		}
	}
}