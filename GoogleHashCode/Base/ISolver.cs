namespace GoogleHashCode.Base
{
	public interface ISolver<in TInput, out TOutput> where TOutput : IOutput
	{
		TOutput Solve(TInput input);
	}
}