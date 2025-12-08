using App;

namespace Days
{
    public class Day3 : ISolve
    {
        public string SolvePartOne(string[] input)
        {
            long totalJoltage = 0;
            foreach (var bank in input)
            {
                var j = GetBankJoltage(bank, 2);
                totalJoltage += long.Parse(string.Join("", j));

            }
            return $"{totalJoltage}";
        }

        public string SolvePartTwo(string[] input)
        {
            long totalJoltage = 0;
            foreach (var bank in input)
            {
                var j = GetBankJoltage(bank, 12);
                totalJoltage += long.Parse(string.Join("", j));

            }
            return $"{totalJoltage}";
        }


        private int[] GetBankJoltage(string bank, int totalBatteriesToTurnOn = 2)
        {
            var batteries = bank.Select((j, index) =>
            {
                _ = int.TryParse(j.ToString(), out int joltage);
                // if its last bank then its weight is 1
                var weight = bank.Length - index;
                var digitWeight = Math.Min(weight, totalBatteriesToTurnOn);
                return new Battery
                {
                    Joltage = joltage,
                    Index = index,
                    DigitWeight = digitWeight,
                };
            }).ToList();

            var batteriesTurnOne = new List<Battery>();

   
            var selectedCandidates = new List<Battery>();

            for (int i = 0; i < totalBatteriesToTurnOn; i++)
            {
                var minIndex = selectedCandidates.Count != 0 ? selectedCandidates[i - 1].Index : -1;
                var wightlimit = totalBatteriesToTurnOn - i;
                var listCandidates = batteries.Where(x => x.DigitWeight >= wightlimit && x.Index > minIndex).OrderByDescending(x => x.Joltage).ToList();
                var hs = listCandidates.FirstOrDefault();
                if (hs != null)
                {
                    selectedCandidates.Add(hs);
                }
            }

            return selectedCandidates.Select(x => x.Joltage).ToArray();
        }

    }
}
class Battery
{
    public int Joltage { get; set; }
    public int Index { get; set; }

    public int DigitWeight { get; set; }

}