using System.Text.RegularExpressions;

namespace Day4;

internal static class Day4
{
    private static bool Contained(int[] ranges)
    {
        return (ranges[0] <= ranges[2] && ranges[1] >= ranges[3]) || // range 1 contains range 2
               (ranges[0] >= ranges[2] && ranges[1] <= ranges[3]);   // range 2 contains range 1
    }
    private static bool Overlapped(int[] ranges)
    {
        return (ranges[0] <= ranges[3] && ranges[3] <= ranges[1]) || // range 1 contains range 2 end
               (ranges[2] <= ranges[1] && ranges[1] <= ranges[3]);   // range 2 contains range 1 end
    }

    public static void Main(string[] args)
    {
        int contained = 0;
        int overlapped = 0;

        foreach (string line in File.ReadLines("./input.txt"))
        {
            int[] ranges = Array.ConvertAll(Regex.Split(line, @"[,-]"), int.Parse);

            if (Contained(ranges)) contained++;
            if (Overlapped(ranges)) overlapped++;
        }

        Console.WriteLine("Part2 Solution: " + contained);
        Console.WriteLine("Part1 Solution: " + overlapped);
    }
}