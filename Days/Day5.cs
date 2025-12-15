using App;

namespace Days
{
    public class Day5 : ISolve
    {
        public string SolvePartOne(string[] input)
        {
            long total = 0;

            List<(long start, long end)> output = new List<(long start, long end)>();
            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var rangeNumebrs = line.Split("-");
                if (rangeNumebrs.Length == 2)
                {
                    long.TryParse(rangeNumebrs[0], out long start);
                    long.TryParse(rangeNumebrs[1], out long end);
                    output.Add((start, end));

                }
                else
                {
                    long.TryParse(line, out long numberToCheck);
                    total += output.Any(x => numberToCheck >= x.start && x.end >= numberToCheck) ? 1 : 0;
                }

            }

            return $"{total}";
        }

        public string SolvePartTwo(string[] input)
        {
            List<(long start, long end)> output = new List<(long start, long end)>();
            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                var rangeNumebrs = line.Split("-");
                if (rangeNumebrs.Length == 2)
                {
                    long.TryParse(rangeNumebrs[0], out long start);
                    long.TryParse(rangeNumebrs[1], out long end);
                    output.Add((start, end));

                }
            }
            var merged = output
                .OrderBy(r => r.start)
                .Aggregate(new List<(long start, long end)>(), (acc, r) =>
                {
                    if (acc.Count == 0)
                    {
                        acc.Add(r);
                        return acc;
                    }

                    var last = acc[^1];

                    if (r.start <= last.end + 1) // lets expand this 
                    {
                        acc[^1] = (last.start, Math.Max(last.end, r.end));
                    }
                    else
                    {
                        acc.Add(r);
                    }

                    return acc;
                });

            return $"{merged.Sum(x => x.end + 1 - x.start)}";
        }
    }


}



