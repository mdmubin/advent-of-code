namespace AOC;

internal static class Day6
{
    private static bool NUniqueChars(string line, int idx, int nChars)
    {
        HashSet<char> chars = new();
        bool allUnique = true;
        for (int i = 0; i < nChars; i++) allUnique &= chars.Add(line[idx - i]);
        return allUnique;
    }


    public static void Main(string[] args)
    {
        using StreamReader reader = new(File.OpenRead("./input.txt"));
        string l = reader.ReadLine()!;

        int i = 3; while (!NUniqueChars(l, i, 4)) i++;
        Console.WriteLine("Part1 Solution: " + (i + 1));

        i = 13; while (!NUniqueChars(l, i, 14)) i++;
        Console.WriteLine("Part2 Solution: " + (i + 1));
    }
}