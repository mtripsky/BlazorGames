using System;
using System.Collections.Generic;

namespace BlazorGames.Games.Minesweeper
{
    public static class GameBoardHelper
    {
        private static bool IsOnBoard((int x, int y) coordinate, int size)
        {
            return coordinate.x >= 0 && coordinate.x < size && coordinate.y >= 0 && coordinate.y < size;
        }

        public static List<(int x, int y)> GetNeighbors((int x, int y) coordinate, int size)
        {
            var result = new List<(int x, int y)>();

            for (var i = -1; i <= 1; ++i)
            {
                if (IsOnBoard((coordinate.x + i, coordinate.y + 1), size))
                {
                    result.Add((coordinate.x + i, coordinate.y + 1));
                }
                if (IsOnBoard((coordinate.x + i, coordinate.y - 1), size))
                {
                    result.Add((coordinate.x + i, coordinate.y - 1));
                }
            }
            if (IsOnBoard((coordinate.x - 1, coordinate.y), size))
            {
                result.Add((coordinate.x - 1, coordinate.y));
            }
            if (IsOnBoard((coordinate.x + 1, coordinate.y), size))
            {
                result.Add((coordinate.x + 1, coordinate.y));
            }

            return result;
        }
    }
}
