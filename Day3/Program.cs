namespace AOC;

static class Day3
{
    private static int GetPriority(char c)
    {
        return c switch
        {
            >= 'a' and <= 'z' => 1 + c - 'a', // if common between 'a' & 'z', nth letter from 'a'
            _ => 27 + c - 'A' // if common between 'A' & 'Z', (n+26)th letter from 'A'
        };
    }

    private static int CommonInRucksack(string rucksackItems)
    {
        HashSet<char> set = new(73);
        for (int i = 0; i < rucksackItems.Length / 2; i++)
            set.Add(rucksackItems[i]);

        char commonItem = '\0';
        for (int i = rucksackItems.Length / 2; i < rucksackItems.Length; i++)
        {
            if (set.Contains(rucksackItems[i]))
            {
                commonItem = rucksackItems[i];
                break;
            }
        }

        return GetPriority(commonItem);
    }

    private static int CommonInElves(string elf1, string elf2, string elf3)
    {
        HashSet<char> elf1Bag = new(73);
        HashSet<char> elf2Bag = new(73);

        foreach (char item in elf1) elf1Bag.Add(item);
        foreach (char item in elf2) elf2Bag.Add(item);

        char badgeValue = elf3.FirstOrDefault(item => elf1Bag.Contains(item) && elf2Bag.Contains(item));

        return GetPriority(badgeValue);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Part1 Solution: " + File.ReadLines("./input.txt").Sum(CommonInRucksack));

        // part2
        StreamReader reader = new(File.OpenRead("./input.txt"));
        int prioritySum = 0;
        while (!reader.EndOfStream)
        {
#pragma warning disable CS8604 // disable null ref warning. ReadLine guaranteed to to find lines to read 3 times in row
            prioritySum += CommonInElves(reader.ReadLine(), reader.ReadLine(), reader.ReadLine());
#pragma warning restore CS8604
        }

        Console.WriteLine("Part2 Solution: " + prioritySum);
        reader.Close();
    }
}