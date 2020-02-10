using System;

namespace BlazorGames.ConnectFour.Data
{
    public class GamePiece
    {
        public PieceColor Color;

        public GamePiece(PieceColor color)
        {
            Color = color;
        }
    }
}
