namespace RoR2RunGenerator;

public static class RandomExtensions
{
    /// <param name="probability">A value between 0.0 and 1.0</param>
    public static bool IsProbabilityHit(this Random random, double probability)
    {
        return Random.Shared.Next(1, 100) <= probability * 100;
    }
}