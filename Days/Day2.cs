using App;

namespace Days
{
    public class Day2 : ISolve
    {
        public string SolvePartOne(string[] input)
        {
            var data = input[0].Split(",");
            long counter = 0;
            foreach (var idRange in data)
            {
                var ids = idRange.Split("-");
                _ = long.TryParse(ids[0], out long min);
                _ = long.TryParse(ids[1], out long max);

                for (long i = min; i <= max; i++)
                {
                    counter += PatternsFoundTwice(i) ? i : 0;
                }

            }
            return $"{counter}";
        }

        public string SolvePartTwo(string[] input)
        {
            throw new NotImplementedException();
        }

        public static bool PatternsFoundTwice(long sampleId)
        {

            var stringifiedId = sampleId.ToString();
            var length = stringifiedId.Length;
            if (length % 2 == 1)
            {
                // i thinks its valid
                return false;
            }
            var firstHalf = stringifiedId[..(length / 2)];
            var secondHalf = stringifiedId[(length / 2)..];
            return firstHalf == secondHalf;
        }

        public static bool PatternsFoundManyTime(long sampleId)
        {

            return false;
        }
    }
}
