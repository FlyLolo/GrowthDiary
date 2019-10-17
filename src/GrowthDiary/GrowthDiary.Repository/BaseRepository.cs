using GrowthDiary.IRepository;
using GrowthDiary.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowthDiary.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected MongoHelper _mongoHelper;
        public T FindById(string id)
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Eq(m => m._id, id);
            return _mongoHelper.Find(filter);
        }

        public List<T> FindAll()
        {
            return _mongoHelper.FindList<T>();
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await _mongoHelper.FindListAsync<T>();
        }

        public void InsertOne(T info)
        {
            _mongoHelper.InsertOne(info);
        }

        public async Task InsertOneAsync(T info)
        {
            await _mongoHelper.InsertOneAsync(info);
        }

        public int UpdateOne(T info, params string[] fields)
        {
            return _mongoHelper.UpdateOne(info, fields: fields);
        }
        public async Task<int> UpdateOneAsync(T info, params string[] fields)
        {
            return await _mongoHelper.UpdateOneAsync(info, fields: fields);
        }

        public int ReplaceOne(T info)
        {
            return _mongoHelper.ReplaceOne(info);
        }

        public async Task<int> ReplaceOneAsync(T info)
        {
            return await _mongoHelper.ReplaceOneAsync(info);
        }
    }
}
