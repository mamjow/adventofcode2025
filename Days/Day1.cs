
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
            pointerPosition = res.Item1;
            // 100 is the new zero
            if (pointerPosition == 0 || pointerPosition == 100)
            {
                zeroCounter++;
            }


        }

        return $"{zeroCounter}";
    }

    public string SolvePartTwo(string[] input)
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
            pointerPosition = res.Item1;
            // 100 is the new zero
            if (pointerPosition == 0 || pointerPosition == 100)
            {
                zeroCounter++;
            }
            zeroCounter += res.Item2;
        }

        return $"{zeroCounter}";
    }

    private static (int,int)  GetNextPointer(int currentPosition, string direction, int jumps)
    {

        var zerosMet = 0;
        if (direction == "L")
        {
            currentPosition -= jumps;

            
        }
        else if (direction == "R")
        {
            currentPosition += jumps;

        }
        
        if (currentPosition < 0) {
            currentPosition = (100 - (Math.Abs(currentPosition) % 100));
            // if negative, then already have met 0 once
            zerosMet = (Math.Abs(currentPosition ) / 100) + 1;
        } else if( currentPosition >= 100) {
            zerosMet = currentPosition / 100;
            currentPosition = currentPosition % 100;
        }
        return (currentPosition,zerosMet);
    }
}


