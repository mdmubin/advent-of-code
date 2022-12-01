namespace AOC
{
    public static class Day1
    {
        public static void Main(string[] args)
        {
            List<int> calories = new(1250);
            int elfCalorie = 0;
            foreach (string line in File.ReadLines("./input.txt"))
            {
                bool hasValue = int.TryParse(line, out int calorie);
                if (hasValue)
                {
                    elfCalorie += calorie;
                }
                else
                {
                    calories.Add(elfCalorie);
                    elfCalorie = 0;
                }
            }

            calories.Sort();
            Console.WriteLine(calories[^1]);
            Console.WriteLine(calories[^1] + calories[^2] + calories[^3]);
        }
    }
}