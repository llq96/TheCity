public static class Random
{
    private static readonly System.Random _random;

    static Random()
    {
        _random = new System.Random();
    }

    public static int Range(int minValue, int maxValue)
    {
        return _random.Next(minValue, maxValue);
    }
}