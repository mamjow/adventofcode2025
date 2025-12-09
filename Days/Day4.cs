using App;

namespace Days
{
    public class Day4 : ISolve
    {
        public string SolvePartOne(string[] input)
        {
            long total = 0;

            var map = input
                        .Select(str => str.Select(ch => ch.ToString()).ToArray())
                        .ToArray();
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    var countPaperNearby = CountCellsAdjacent(map, i, j, "@");
                    if (GetCell(map, i, j) == "@" && countPaperNearby < 4)
                    {
                        total += 1;
                    }
                }
            }
            return $"{total}";
        }

        public string SolvePartTwo(string[] input)
        {
            long total = 0;
            var iterationDone = false;

            var map = input
                        .Select(str => str.Select(ch => ch.ToString()).ToArray())
                        .ToArray();
            while (!iterationDone)
            {
                var innerChange = 0;
                for (int i = 0; i < map.Length; i++)
                {
                    if (!map[i].Any(x => x == "@"))
                    {
                        continue;
                    }
                    for (int j = 0; j < map[i].Length; j++)
                    {
                        var countPaperNearby = CountCellsAdjacent(map, i, j, "@");
                        if (GetCell(map, i, j) == "@" && countPaperNearby < 4)
                        {
                            innerChange += 1;
                            map[i][j] = ".";
                        }
                    }
                }

                total += innerChange;
                if (innerChange == 0)
                {
                    iterationDone = true;
                }
            }

            return $"{total}";
        }

        public int CountCellsAdjacent(string[][] map, int x, int y, string cell = "@")
        {
            int count = 0;
            // top row 3 
            count += GetCell(map, x - 1, y - 1) == cell ? 1 : 0;
            count += GetCell(map, x - 1, y) == cell ? 1 : 0;
            count += GetCell(map, x - 1, y + 1) == cell ? 1 : 0;

            // curent row before after
            count += GetCell(map, x, y - 1) == cell ? 1 : 0;
            count += GetCell(map, x, y + 1) == cell ? 1 : 0;

            // row below 3
            count += GetCell(map, x + 1, y - 1) == cell ? 1 : 0;
            count += GetCell(map, x + 1, y) == cell ? 1 : 0;
            count += GetCell(map, x + 1, y + 1) == cell ? 1 : 0;
            return count;
        }

        public string GetCell(string[][] map, int x, int y)
        {
            if (map == null || x < 0 || x >= map.Length)
                return string.Empty;

            var row = map[x];
            if (row == null || y < 0 || y >= row.Length)
                return string.Empty;

            return row[y];
        }

    }
}



