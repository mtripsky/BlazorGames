using MongoDB.Driver;

namespace BlazorGames.Services
{
    public interface IDatabaseClient<T>
    {
        IMongoCollection<T> GetCollection(string name);
    }
}
