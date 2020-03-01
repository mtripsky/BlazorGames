using System;

namespace BlazorGames.Data.GameDb
{
    public class MinesweeperGameResult : IEntity
    {
        public Guid Id { get; set; }

        public string PlayerName { get; set; }

        public int BoardSizeX { get; set; }

        public int BoardSizeY { get; set; }

        public int MinesCount { get; set; }

        public TimeSpan GameTime { get; set; }
    }
}
