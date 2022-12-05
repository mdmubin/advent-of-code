using System.Text.RegularExpressions;

namespace AOC;

internal static class Day5
{
    public static void Main(string[] args)
    {
        Stack<char>[] crates1 = // decided to hard-code the stacks. For part-1
        {
            new(new[] { 'Z', 'J', 'N', 'W', 'P', 'S' }),
            new(new[] { 'G', 'S', 'T' }),
            new(new[] { 'V', 'Q', 'R', 'L', 'H' }),
            new(new[] { 'V', 'S', 'T', 'D' }),
            new(new[] { 'Q', 'Z', 'T', 'D', 'B', 'M', 'J' }),
            new(new[] { 'M', 'W', 'T', 'J', 'D', 'C', 'Z', 'L' }),
            new(new[] { 'L', 'P', 'M', 'W', 'G', 'T', 'J' }),
            new(new[] { 'N', 'G', 'M', 'T', 'B', 'F', 'Q', 'H' }),
            new(new[] { 'R', 'D', 'G', 'C', 'P', 'B', 'Q', 'W' }),
        };

        Stack<char>[] crates2 = // decided to hard-code the stacks. For part-2
        {
            new(new[] { 'Z', 'J', 'N', 'W', 'P', 'S' }),
            new(new[] { 'G', 'S', 'T' }),
            new(new[] { 'V', 'Q', 'R', 'L', 'H' }),
            new(new[] { 'V', 'S', 'T', 'D' }),
            new(new[] { 'Q', 'Z', 'T', 'D', 'B', 'M', 'J' }),
            new(new[] { 'M', 'W', 'T', 'J', 'D', 'C', 'Z', 'L' }),
            new(new[] { 'L', 'P', 'M', 'W', 'G', 'T', 'J' }),
            new(new[] { 'N', 'G', 'M', 'T', 'B', 'F', 'Q', 'H' }),
            new(new[] { 'R', 'D', 'G', 'C', 'P', 'B', 'Q', 'W' }),
        };

        Regex inputFormat = new(@"move (?<count>\d+) from (?<fromIdx>\d+) to (?<toIdx>\d+)");

        foreach (string line in File.ReadLines("./input.txt"))
        {
            Match pattern = inputFormat.Match(line);

            int count = int.Parse(pattern.Groups["count"].Value);
            int fromIdx = int.Parse(pattern.Groups["fromIdx"].Value) - 1;
            int toIdx = int.Parse(pattern.Groups["toIdx"].Value) - 1;

            for (int i = 0; i < count; i++)
                crates1[toIdx].Push(crates1[fromIdx].Pop());

            Stack<char> temp = new();
            for (int i = 0; i < count; i++) temp.Push(crates2[fromIdx].Pop());
            for (int i = 0; i < count; i++) crates2[toIdx].Push(temp.Pop());
        }

        Console.Write("Part1 Solution: ");
        foreach (Stack<char> crate in crates1) Console.Write(crate.Peek());
        Console.WriteLine();
        
        Console.Write("Part2 Solution: ");
        foreach (Stack<char> crate in crates2) Console.Write(crate.Peek());
        Console.WriteLine();
    }
}