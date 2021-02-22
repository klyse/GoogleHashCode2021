using GoogleHashCode.Model;

namespace GoogleHashCode.Base
{
	public interface IOutput
	{
		string[] GetOutputFormat();
		int GetScore(Input input);
	}
}