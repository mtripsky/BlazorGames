using System;

namespace BlazorGames.Data.Minesweeper
{
    public class GamePiece
    {
        public PieceColor Color;

        public int NeighborBombCount;

        public bool IsRevealed;

        public bool IsMine;

        public GamePiece(PieceColor color)
        {
            Color = color;
        }
    }
}
