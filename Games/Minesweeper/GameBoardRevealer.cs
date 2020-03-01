using BlazorGames.Data.Minesweeper;

namespace BlazorGames.Games.Minesweeper
{
    public static class GameBoardRevealer
    {
        public static void Reveale(GameBoard board, (int x, int y) coordinate, int size)
        {
            if (board.Board[coordinate.x, coordinate.y].IsRevealed) return;

            board.Board[coordinate.x, coordinate.y].IsRevealed = true;

            foreach (var neighborCoordinate in GameBoardHelper.GetNeighbors(coordinate, size))
            {
                if (board.Board[neighborCoordinate.x, neighborCoordinate.y].NeighborBombCount == 0)
                {
                    board.Board[neighborCoordinate.x, neighborCoordinate.y].Color = PieceColor.Blank;
                    Reveale(board, neighborCoordinate, size);
                }
                else
                {
                    board.Board[neighborCoordinate.x, neighborCoordinate.y].IsRevealed = true;
                    board.Board[neighborCoordinate.x, neighborCoordinate.y].Color = PieceColor.NeighborBomb;
                }
            }
        }
    }
}
