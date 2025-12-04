using System.Text.RegularExpressions;
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
            var data = input[0].Split(",");
            long counter = 0;
            foreach (var idRange in data)
            {
                var ids = idRange.Split("-");
                _ = long.TryParse(ids[0], out long min);
                _ = long.TryParse(ids[1], out long max);

                for (long i = min; i <= max; i++)
                {
                    counter += PatternsFoundManyTime(i) ? i : 0;
                }

            }
            return $"{counter}";
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
            var stringifiedId = sampleId.ToString();
            
            for (var i = 1; i <= stringifiedId.Length/2; i++)
            {
                // at least 2 so we nex just to check pattersn to half
                var sub = stringifiedId[..i];
                var occurance = Regex.Matches(stringifiedId, sub).Count();;
                // ocurance times length musb be whole string size
                if(occurance * sub.Length == stringifiedId.Length)
                {
                    return true;
                }      
            }

            return false;
        }
    }
}
