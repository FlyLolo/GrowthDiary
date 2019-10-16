using GrowthDiary.IRepository;
using GrowthDiary.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrowthDiary.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        public T GetById(string id)
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Eq(m => m._id, id);
            return MongoHelper.Find(filter);
        }

        public List<T> GetList()
        {
            return MongoHelper.FindList<T>();
        }

        public void Add(T info)
        {
            MongoHelper.InsertOne(info);
        }

        public int Update(T info, params string[] fields)
        {
            return MongoHelper.UpdateOne(info, fields: fields);
        }
        public async Task<int> UpdateAsync(T info, params string[] fields)
        {
            return await MongoHelper.UpdateOneAsync(info, fields: fields);
        }

        public int ReplaceOne(T info)
        {
            return MongoHelper.ReplaceOne(info);
        }

        public async Task<int> ReplaceOneAsync(T info)
        {
            return await MongoHelper.ReplaceOneAsync(info);
        }
    }
}
