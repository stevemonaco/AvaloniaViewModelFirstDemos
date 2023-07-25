namespace Shared.Services;

public interface IRandomService
{
    int GetNext(int minInclusive, int maxExclusive);
}

public class RandomService : IRandomService
{
    public int GetNext(int minInclusive, int maxExclusive) => Random.Shared.Next(minInclusive, maxExclusive);
}
