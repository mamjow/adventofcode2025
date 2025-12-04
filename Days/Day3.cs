using App;

namespace Days
{
    public class Day3 : ISolve
    {
        public string SolvePartOne(string[] input)
        {
            var totalJoltage = 0;
            foreach (var bank in input)
            {
                totalJoltage += GetBackJoltage(bank);

            }
            return $"{totalJoltage}";
        }

        public string SolvePartTwo(string[] input)
        {

            return $"";
        }

        private int GetBackJoltage(string bank)
        {
            var batteries = bank.ToList().Select((j, index) =>
            {
                _ = int.TryParse(j.ToString(), out int joltage);
                return new
                {
                    joltage,
                    index
                };
            }).OrderByDescending(x => x.joltage)
            .GroupBy(x => x.joltage)
            .ToDictionary(x => x.Key, x => x.OrderBy(x => x.index).ToList()).Values.ToList();

            // if ther is only max digit in list then 
            if (batteries.Count == 1)
            {
                return int.Parse($"{batteries[0][0].joltage}{batteries[0][0].joltage}");
            }


            int firtsMaxJoltageCandidateIndex = 0;
            int SecondMaxJoltageCandidateIndex = 1;

            var maxJoltageObj = batteries[firtsMaxJoltageCandidateIndex][0];

            for (int i = SecondMaxJoltageCandidateIndex; i < batteries.Count;)
            {
                // if there is a lower number with higher index
                if (batteries[i][0].index > maxJoltageObj.index )
                {
                    // nice
                    return int.Parse($"{maxJoltageObj.joltage}{batteries[i][0].joltage}"); ;
                }
                else if( i != batteries.Count - 1)
                {
                    i++;
                }
                else
                {
                    // there is no hope for this joltage. pick nex candidate
                    firtsMaxJoltageCandidateIndex = SecondMaxJoltageCandidateIndex;
                    maxJoltageObj = batteries[SecondMaxJoltageCandidateIndex][0];
                    i = 0;
                    SecondMaxJoltageCandidateIndex = 0;
                }
            }
    // last bad 16250
            return int.Parse($"{maxJoltageObj.joltage}{batteries[SecondMaxJoltageCandidateIndex][0].joltage}"); ;
        }

    }
}
