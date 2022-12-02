namespace AOC
{
    public static class Day2
    {
        private static int Part1(string match)
        {
            int elf = match[0] - 'A' + 1,
                own = match[2] - 'X' + 1;
            int outcome = elf == own ? 1 : (elf - own + 2) % 3 == 0 ? 0 : 2;
            return own + outcome * 3;
        }
        
        private static int Part2(string match)
        {
            int elf = match[0] - 'A';
            return match[2] switch
            {
                'X' => (elf + 2) % 3 + 1,
                'Y' => elf + 4,
                'Z' => (elf + 1) % 3 + 7,
                 _  => throw new Exception("This should be unreachable!")
            };
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Part1 Solution = " + File.ReadLines("./input.txt").Sum(Part1));
            Console.WriteLine("Part2 Solution = " + File.ReadLines("./input.txt").Sum(Part2));
        }
    }
}