using System.Globalization;
using System.Text;
using App;

namespace Days
{
    public class Day6 : ISolve
    {
        public string SolvePartOne(string[] input)
        {
            long answer = 0;

            var mathworks = input[^1].Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(x => (Ops: x, Nums: new List<long>())).ToList();

            foreach (var line in input[..^1])
            {
                var numbers = line.Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(x => long.Parse(x)).ToList();
                for (int i = 0; i < numbers.Count; i++)
                {
                    mathworks[i].Nums.Add(numbers[i]);
                }
            }


            foreach (var item in mathworks)
            {
                long rowAnswer = item.Ops switch
                {
                    "*" => item.Nums.Aggregate(1L, (lis, n) => lis * n),
                    "+" => item.Nums.Sum(),
                    _ => throw new NotImplementedException(),
                };
                answer += rowAnswer;
            }

            return $"{answer}";
        }

        public string SolvePartTwo(string[] input)
        {
            long answer = 0;
            var matRows = SplitByCommonWhitespaces(input);

            var totalCOl = matRows[0].Length;


            for (int colCell = 0; colCell < totalCOl; colCell++)
            {

                var cellsIncol = matRows.Select(x => x[colCell]).ToArray();
                var numberst = ReadNumbersVertically(cellsIncol[..^1]);

                long rowAnswer = cellsIncol[^1].Trim() switch
                {
                    "*" => numberst.Aggregate(1L, (lis, n) => lis * n),
                    "+" => numberst.Sum(),
                    _ => throw new NotImplementedException(),
                };
                answer += rowAnswer;
            }

            return $"{answer}";
        }


        static List<string[]> SplitByCommonWhitespaces(string[] lanes)
        {
            var whitespaces = lanes.Select(line =>
            {
                var setOfIndices = new HashSet<int>();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ' ')
                    {
                        setOfIndices.Add(i);
                    }
                }
                return setOfIndices;
            });

            var commonIndices = whitespaces
                .Skip(1)
                .Aggregate(
                    new HashSet<int>(whitespaces.First()),
                    (cleanWhitespace, setItem) => { cleanWhitespace.IntersectWith(setItem); return cleanWhitespace; }
                )
                .OrderBy(i => i)
                .ToList();

            List<string[]> result = [.. lanes.Select(x => SliceOnIndices(x, commonIndices))];
            return result;
        }

        public static string[] SliceOnIndices(string value, List<int> indices)
        {
            // last slice is with rest of string
            var slices = new string[indices.Count + 1];

            // start As 0 - end As first index
            // so one last part remains out of foor loop
            int start = 0;

            for (int i = 0; i < indices.Count; i++)
            {
                slices[i] = value[start..indices[i]];
                // we dont want that index
                start = indices[i] + 1;
            }
            // last piece
            slices[^1] = start <= value.Length ? value[start..] : string.Empty;
            return slices;
        }

        public static long[] ReadNumbersVertically(string[] input)
        {
            // start at x 0 y 1 to x 0 y length
            // each x itteration is a number
            var totalNumbers = input[0].Length;
            var nums = new long[totalNumbers];

            // assuming the length of them are correct
            var area = totalNumbers * input.Length;
            if (input.Sum(x => x.Length) != area)
            {
                return [];
            }

            // so for the length of 
            var sb = new StringBuilder();
            for (int x = 0; x < nums.Length; x++)
            {

                for (int y = 0; y < input.Length; y++)
                {
                    sb.Append(input[y][x]);
                }
                nums[x] = long.Parse(sb.ToString());
                sb.Clear();
            }

            return nums;
        }
    }


}




