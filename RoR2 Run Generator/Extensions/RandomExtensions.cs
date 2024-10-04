namespace RoR2RunGenerator.Extensions;

public static class RandomExtensions
{
    /// <param name="probability">A value between 0.0 and 1.0</param>
    // ReSharper disable once InvalidXmlDocComment
    public static bool IsProbabilityHit(this Random random, double probability)
    {
        return random.Next(1, 100) <= probability * 100;
    }
}