using System;
using System.Collections.Generic;
using BlazorGames.Data.Minesweeper;
using System.Linq;

namespace BlazorGames.Games.Minesweeper
{
    public class GameBoardGenerator
    {
        public GameBoard Generate(int size, int mineCount)
        {
            var board = new GameBoard(size);

            var coordinates = new List<(int x, int y)>();
            for (var x = 0; x < size; ++x)
            {
                for(var y = 0; y < size; ++y)
                {
                    coordinates.Add((x, y));
                }
            }
            var bombCoordinates = coordinates.Shuffle().Take(mineCount);

            foreach(var c in bombCoordinates)
            {
                board.Board[c.x, c.y].IsMine = true;
                UpdateNeigborCount(board, c, size);
            }
            
            return board;
        }

        private void UpdateNeigborCount(GameBoard board, (int x, int y) c, int size)
        {
            for (var i = -1; i <= 1; ++i)
            {
                if(IsOnBoard((c.x + i, c.y + 1), size))
                {
                    board.Board[c.x + i, c.y + 1].NeighborBombCount += 1;
                }
                if (IsOnBoard((c.x + i, c.y - 1), size))
                {
                    board.Board[c.x + i, c.y - 1].NeighborBombCount += 1;
                }
            }
            if (IsOnBoard((c.x - 1, c.y), size))
            {
                board.Board[c.x - 1, c.y].NeighborBombCount += 1;
            }
            if (IsOnBoard((c.x + 1, c.y), size))
            {
                board.Board[c.x + 1, c.y].NeighborBombCount += 1;
            }
        }

        private bool IsOnBoard((int x, int y) c, int size)
        {
            return c.x >= 0 && c.x < size && c.y >= 0 && c.y < size;
        }
    }
}
