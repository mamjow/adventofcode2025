
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using App;
namespace Days;

public class Day1 : ISolve
{
    public string SolvePartOne(string[] input)
    {
        var pointerPosition = 50;
        var zeroCounter = 0;
        foreach (var line in input)
        {
            var match = Regex.Match(line, @"(L|R)(\d*)");

            if (!match.Success)
            {
                throw new InvalidDataException("Invalid Puzzel input");
            }
            string direction = match.Groups[1].Value; // "L"
            _ = int.TryParse(match.Groups[2].Value, out var jumps);
            var res = GetNextPointer(pointerPosition, direction, jumps);
            pointerPosition = res;
            if (pointerPosition == 0 )
            {
                zeroCounter++;
            }

        }

        return $"{zeroCounter}";
    }

    public string SolvePartTwo(string[] input)
    {

        var leftList = new List<int>();
        var rightList = new List<int>();
        foreach (var line in input)
        {
            var numbers = Regex.Matches(line, @"(L|R)(\d*)");
            _ = int.TryParse(numbers[0].Value, out var Leftdig);
            _ = int.TryParse(numbers[1].Value, out var rightDig);
            leftList.Add(Leftdig);
            rightList.Add(rightDig);
        }
        leftList.Sort();
        rightList.Sort();

        var distanceList = new List<int>();
        for (int i = 0; i < leftList.Count; i++)
        {
            var countOccurance = rightList.Count(x => x == leftList[i]);
            distanceList.Add(leftList[i] * countOccurance);
        }
        return "";
    }

    private static int  GetNextPointer(int currentPosition, string direction, int jumps)
    {

        if (direction == "L")
        {
            currentPosition -= jumps;

            
        }
        else if (direction == "R")
        {
            currentPosition += jumps;

        }
        currentPosition = currentPosition < 0 ? (100 - (Math.Abs(currentPosition) % 100)) : currentPosition;
        currentPosition = currentPosition >= 100 ? currentPosition % 100 : currentPosition;
        return currentPosition;
    }
}


