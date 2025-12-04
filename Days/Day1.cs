
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
            pointerPosition = p.Item1;
            zeroCounter += p.Item2;
        }

        return $"{zeroCounter}";
    }


    public static (int, int) GetNextPointer(int currentPosition, int jumps)
    {
        var newRawPos = currentPosition + jumps;

        var currentpos = Mod(newRawPos, 100);

        var zerosMet = Math.Abs(newRawPos / 100);

        if (newRawPos <= 0 && currentPosition != 0) {
            zerosMet++;
        }

        return (currentpos, zerosMet);
    }

    public static int Mod(int a, int b)
    {
        return (a % b + b) % b;
    }
}




