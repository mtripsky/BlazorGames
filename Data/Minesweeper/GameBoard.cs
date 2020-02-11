using System;

namespace BlazorGames.Data.Minesweeper
{
    public class GameBoard
    {
        public GamePiece[,] Board { get; set; }

        public GameBoard(int size)
        {
            Board = new GamePiece[size, size];

            //Populate the Board with blank pieces
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Board[i, j] = new GamePiece(PieceColor.Initial);
                }
            }
        }
    }
}