
using App;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security;
using System.Text.RegularExpressions;
namespace Days;

public class Day1 : ISolve
{
    public string SolvePartOne(string[] input)
    {
        var pointerPosition = 50;
        var zeroCounter = 0;
        foreach (var line in input)
        {
            var cleanLine = line.Replace("L", "-").Replace("R", "+");
            _ = int.TryParse(cleanLine, out int jump);
            var p = GetNextPointer(pointerPosition, jump);
            pointerPosition = p.Item1;
            if (pointerPosition == 0)
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

            var cleanLine = line.Replace("L", "-").Replace("R", "+");

            _ = int.TryParse(cleanLine, out int jump);
            var p = GetNextPointer(pointerPosition, jump);

            zeroCounter += p.Item2;
        }

        // 5782
        return $"{zeroCounter}";
    }


    private static (int, int) GetNextPointer(int currentPosition, int jumps)
    {
        var newRawPos = currentPosition + jumps;

        var currentpos = Mod(newRawPos, 100);



        return (currentpos, 0);
    }


    public static int Mod(int a, int b)
    {
        return (a % b + b) % b;
    }
}


