using System.Collections.Generic;
using BlazorGames.Data.Minesweeper;
using System.Linq;

namespace BlazorGames.Games.Minesweeper
{
    public static class GameBoardGenerator
    {
        public static GameBoard Generate(int size, int mineCount)
        {
            var board = new GameBoard(size);

            var coordinates = new List<(int x, int y)>();
            for (var x = 0; x < size; ++x)
            {
                for (var y = 0; y < size; ++y)
                {
                    coordinates.Add((x, y));
                }
            }
            var bombCoordinates = coordinates.Shuffle().Take(mineCount);

            foreach (var coordinate in bombCoordinates)
            {
                board.Board[coordinate.x, coordinate.y].IsMine = true;
                foreach (var neighborCoordinate in GameBoardHelper.GetNeighbors(coordinate, size))
                {
                    board.Board[neighborCoordinate.x, neighborCoordinate.y].NeighborBombCount += 1;
                }
            }

            return board;
        }
    }
}
