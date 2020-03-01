using System;
using System.Collections.Generic;
using System.Linq;
using BlazorGames.Data.GameDb;
using MongoDB.Driver;

namespace BlazorGames.Services
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
        where T : IEntity
    {
        private readonly IMongoCollection<T> _collection;

        public EntityBaseRepository(IDatabaseClient<T> client, string name)
        {
            _collection = client.GetCollection(name);
        }

        public int Count()
        {
            return GetAll().Count();
        }

        public T Create(T entity)
        {
            _collection.InsertOne(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _collection.DeleteOne(e => e.Id == entity.Id);
        }

        public void Delete(Guid id)
        {
            _collection.DeleteOne(e => e.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _collection.Find(p => true).ToList();
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return _collection.AsQueryable().Where(predicate);
        }

        public T GetSingle(Guid id)
        {
            var entity = _collection.Find(p => p.Id == id).FirstOrDefault();

            return entity;
        }

        public T GetSingle(Func<T, bool> predicate)
        {
            var entity = _collection.AsQueryable().FirstOrDefault(predicate);

            return entity;
        }

        public void Update(Guid id, T entity)
        {
            _collection.ReplaceOne(e => e.Id == id, entity);
        }
    }
}
