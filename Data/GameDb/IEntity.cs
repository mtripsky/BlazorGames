using System;
namespace BlazorGames.Data.GameDb
{
    public interface IEntity
    {
        System.Guid Id { get; set; }
    }
}
