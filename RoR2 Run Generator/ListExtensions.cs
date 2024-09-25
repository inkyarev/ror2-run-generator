namespace RoR2RunGenerator;

public static class ListExtensions
{
    public static T Random<T>(this IList<T> list)
    {
        return list[System.Random.Shared.Next(0, list.Count)];
    }
}